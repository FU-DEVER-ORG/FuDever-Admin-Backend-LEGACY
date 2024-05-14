using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Admin.ApproveNewUser;

/// <summary>
///     Approve new user request handler.
/// </summary>
internal sealed class ApproveNewUserRequestHandler
    : IRequestHandler<ApproveNewUserRequest, ApproveNewUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public ApproveNewUserRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    ///     Entry of new request handler.
    /// </summary>
    /// <param name="request">
    ///     Request model.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used for notifying system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     A task containing the response.
    /// </returns>
    public async Task<ApproveNewUserResponse> Handle(
        ApproveNewUserRequest request,
        CancellationToken cancellationToken
    )
    {
        // Does user exist by user id.
        var isUserFound =
            await _unitOfWork.AdminFeature.ApproveNewUser.Query.IsUserFoundByUserIdQueryAsync(
                userId: request.UserId,
                cancellationToken: cancellationToken
            );

        // User with user id does not exists.
        if (!isUserFound)
        {
            return new() { StatusCode = ApproveNewUserResponseStatusCode.USER_IS_NOT_FOUND };
        }

        // Is user not temporarily removed.
        var isUserNotTemporarilyRemoved =
            await _unitOfWork.AdminFeature.ApproveNewUser.Query.IsUserNotTemporarilyRemovedQueryAsync(
                userId: request.UserId,
                cancellationToken: cancellationToken
            );

        // User is temporarily removed.
        if (!isUserNotTemporarilyRemoved)
        {
            return new()
            {
                StatusCode = ApproveNewUserResponseStatusCode.USER_IS_TEMPORARILY_REMOVED
            };
        }

        // Get user joining status.
        var userDetail =
            await _unitOfWork.AdminFeature.ApproveNewUser.Query.GetUserJoiningStatusQueryAsync(
                userId: request.UserId,
                cancellationToken: cancellationToken
            );

        // User with user id is already approved by admin.
        if (userDetail.UserJoiningStatus.Type.Equals(value: "Approved"))
        {
            return new() { StatusCode = ApproveNewUserResponseStatusCode.USER_IS_ALREADY_APPROVED };
        }

        // User with user id is already rejected.
        if (userDetail.UserJoiningStatus.Type.Equals(value: "Rejected"))
        {
            return new() { StatusCode = ApproveNewUserResponseStatusCode.USER_IS_ALREADY_REJECTED };
        }

        //// User with user id is already expired.
        //if (userDetail.UserJoiningStatus.Type.Equals(value: "Expired"))
        //{
        //    return new()
        //    {
        //        StatusCode = ApproveNewUserResponseStatusCode.USER_IS_ALREADY_EXPIRED
        //    };
        //}

        // Get user approve status id.
        var approvedStatus =
            await _unitOfWork.AdminFeature.ApproveNewUser.Query.GetApprovedUserJoiningStatusQueryAsync(
                cancellationToken: cancellationToken
            );

        // Approve user with user id.
        var dbResult =
            await _unitOfWork.AdminFeature.ApproveNewUser.Command.ApproveUserCommandAsync(
                userId: request.UserId,
                approvedUserJoiningStatusId: approvedStatus.Id,
                cancellationToken: cancellationToken
            );

        // Cannot approve user with user id.
        if (!dbResult)
        {
            return new() { StatusCode = ApproveNewUserResponseStatusCode.DATABASE_OPERATION_FAIL };
        }

        return new() { StatusCode = ApproveNewUserResponseStatusCode.OPERATION_SUCCESS };
    }
}
