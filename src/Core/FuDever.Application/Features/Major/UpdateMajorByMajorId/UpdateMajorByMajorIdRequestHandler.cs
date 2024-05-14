using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Major.UpdateMajorByMajorId;

/// <summary>
///     Update major by major id request handler.
/// </summary>
internal sealed class UpdateMajorByMajorIdRequestHandler
    : IRequestHandler<UpdateMajorByMajorIdRequest, UpdateMajorByMajorIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMajorByMajorIdRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<UpdateMajorByMajorIdResponse> Handle(
        UpdateMajorByMajorIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is major found by major id.
        var isMajorFoundByMajorId =
            await _unitOfWork.MajorFeature.UpdateMajorByMajorId.Query.IsMajorFoundByMajorIdQueryAsync(
                majorId: request.MajorId,
                cancellationToken: cancellationToken
            );

        // Major is not found by major id.
        if (!isMajorFoundByMajorId)
        {
            return new() { StatusCode = UpdateMajorByMajorIdResponseStatusCode.MAJOR_IS_NOT_FOUND };
        }

        // Is major temporarily removed by major id.
        var isMajorTemporarilyRemoved =
            await _unitOfWork.MajorFeature.UpdateMajorByMajorId.Query.IsMajorTemporarilyRemovedByMajorIdQueryAsync(
                majorId: request.MajorId,
                cancellationToken: cancellationToken
            );

        // Major is already temporarily removed by major id.
        if (isMajorTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    UpdateMajorByMajorIdResponseStatusCode.MAJOR_IS_ALREADY_TEMPORARILY_REMOVED
            };
        }

        // Is major with the same major name found.
        var isMajorWithTheSameNameFound =
            await _unitOfWork.MajorFeature.UpdateMajorByMajorId.Query.IsMajorWithTheSameNameFoundByMajorNameQueryAsync(
                newMajorName: request.NewMajorName,
                cancellationToken: cancellationToken
            );

        // Major with the same major name is found.
        if (isMajorWithTheSameNameFound)
        {
            return new()
            {
                StatusCode = UpdateMajorByMajorIdResponseStatusCode.MAJOR_ALREADY_EXISTS
            };
        }

        // Update major by major id.
        var result =
            await _unitOfWork.MajorFeature.UpdateMajorByMajorId.Command.UpdateMajorByMajorIdCommandAsync(
                majorId: request.MajorId,
                newMajorName: request.NewMajorName,
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode = UpdateMajorByMajorIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new() { StatusCode = UpdateMajorByMajorIdResponseStatusCode.OPERATION_SUCCESS };
    }
}
