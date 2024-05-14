using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;

namespace FuDever.Application.Features.Major.RemoveMajorTemporarilyByMajorId;

/// <summary>
///     Remove major temporarily by major id request handler.
/// </summary>
internal sealed class RemoveMajorTemporarilyByMajorIdRequestHandler
    : IRequestHandler<
        RemoveMajorTemporarilyByMajorIdRequest,
        RemoveMajorTemporarilyByMajorIdResponse
    >
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RemoveMajorTemporarilyByMajorIdRequestHandler(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
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
    public async Task<RemoveMajorTemporarilyByMajorIdResponse> Handle(
        RemoveMajorTemporarilyByMajorIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is major found by major id.
        var isMajorFoundByMajorId =
            await _unitOfWork.MajorFeature.RemoveMajorTemporarilyByMajorId.Query.IsMajorFoundByMajorIdQueryAsync(
                majorId: request.MajorId,
                cancellationToken: cancellationToken
            );

        // Major is not found by major id.
        if (!isMajorFoundByMajorId)
        {
            return new()
            {
                StatusCode = RemoveMajorTemporarilyByMajorIdResponseStatusCode.MAJOR_IS_NOT_FOUND
            };
        }

        // Is major temporarily removed by major id.
        var isMajorTemporarilyRemoved =
            await _unitOfWork.MajorFeature.RemoveMajorTemporarilyByMajorId.Query.IsMajorTemporarilyRemovedByMajorIdQueryAsync(
                majorId: request.MajorId,
                cancellationToken: cancellationToken
            );

        // Major is already temporarily removed by major id.
        if (isMajorTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    RemoveMajorTemporarilyByMajorIdResponseStatusCode.MAJOR_IS_ALREADY_TEMPORARILY_REMOVED
            };
        }

        // Update major by major id.
        var result =
            await _unitOfWork.MajorFeature.RemoveMajorTemporarilyByMajorId.Command.RemoveMajorTemporarilyByMajorIdCommandAsync(
                majorId: request.MajorId,
                removedAt: DateTime.UtcNow,
                removedBy: Guid.Parse(
                    input: _httpContextAccessor.HttpContext.User.FindFirstValue(
                        claimType: JwtRegisteredClaimNames.Sub
                    )
                ),
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode =
                    RemoveMajorTemporarilyByMajorIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new()
        {
            StatusCode = RemoveMajorTemporarilyByMajorIdResponseStatusCode.OPERATION_SUCCESS
        };
    }
}
