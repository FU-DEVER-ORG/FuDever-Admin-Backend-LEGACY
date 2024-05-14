using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Data;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Major.RestoreMajorByMajorId;

/// <summary>
///     Restore major by major id request handler.
/// </summary>
internal sealed class RestoreMajorByMajorIdRequestHandler
    : IRequestHandler<RestoreMajorByMajorIdRequest, RestoreMajorByMajorIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDbMinTimeHandler _dbMinTimeHandler;

    public RestoreMajorByMajorIdRequestHandler(
        IUnitOfWork unitOfWork,
        IDbMinTimeHandler dbMinTimeHandler
    )
    {
        _unitOfWork = unitOfWork;
        _dbMinTimeHandler = dbMinTimeHandler;
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
    public async Task<RestoreMajorByMajorIdResponse> Handle(
        RestoreMajorByMajorIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is major found by major id.
        var isMajorFoundByMajorId =
            await _unitOfWork.MajorFeature.RestoreMajorByMajorId.Query.IsMajorFoundByMajorIdQueryAsync(
                majorId: request.MajorId,
                cancellationToken: cancellationToken
            );

        // Major is not found by major id.
        if (!isMajorFoundByMajorId)
        {
            return new()
            {
                StatusCode = RestoreMajorByMajorIdResponseStatusCode.MAJOR_IS_NOT_FOUND
            };
        }

        // Is major temporarily removed by major id.
        var isMajorTemporarilyRemoved =
            await _unitOfWork.MajorFeature.RestoreMajorByMajorId.Query.IsMajorTemporarilyRemovedByMajorIdQueryAsync(
                majorId: request.MajorId,
                cancellationToken: cancellationToken
            );

        // Major is not temporarily removed by major id.
        if (!isMajorTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    RestoreMajorByMajorIdResponseStatusCode.MAJOR_IS_NOT_TEMPORARILY_REMOVED
            };
        }

        // Remove major permanently by major id.
        var result =
            await _unitOfWork.MajorFeature.RestoreMajorByMajorId.Command.RestoreMajorByMajorIdCommandAsync(
                majorId: request.MajorId,
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode = RestoreMajorByMajorIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new() { StatusCode = RestoreMajorByMajorIdResponseStatusCode.OPERATION_SUCCESS };
    }
}
