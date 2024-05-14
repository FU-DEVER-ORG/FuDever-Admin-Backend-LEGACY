using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;

namespace FuDever.Application.Features.Platform.RemovePlatformTemporarilyByPlatformId;

/// <summary>
///     Remove platform temporarily by platform id request handler.
/// </summary>
internal sealed class RemovePlatformTemporarilyByPlatformIdRequestHandler
    : IRequestHandler<
        RemovePlatformTemporarilyByPlatformIdRequest,
        RemovePlatformTemporarilyByPlatformIdResponse
    >
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RemovePlatformTemporarilyByPlatformIdRequestHandler(
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
    public async Task<RemovePlatformTemporarilyByPlatformIdResponse> Handle(
        RemovePlatformTemporarilyByPlatformIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is platform found by platform id.
        var isPlatformFoundByPlatformId =
            await _unitOfWork.PlatformFeature.RemovePlatformTemporarilyByPlatformId.Query.IsPlatformFoundByPlatformIdQueryAsync(
                platformId: request.PlatformId,
                cancellationToken: cancellationToken
            );

        // Platform is not found by platform id.
        if (!isPlatformFoundByPlatformId)
        {
            return new()
            {
                StatusCode =
                    RemovePlatformTemporarilyByPlatformIdResponseStatusCode.PLATFORM_IS_NOT_FOUND
            };
        }

        // Is platform temporarily removed by platform id.
        var isPlatformTemporarilyRemoved =
            await _unitOfWork.PlatformFeature.RemovePlatformTemporarilyByPlatformId.Query.IsPlatformTemporarilyRemovedByPlatformIdQueryAsync(
                platformId: request.PlatformId,
                cancellationToken: cancellationToken
            );

        // Platform is already temporarily removed by platform id.
        if (isPlatformTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    RemovePlatformTemporarilyByPlatformIdResponseStatusCode.PLATFORM_IS_ALREADY_TEMPORARILY_REMOVED
            };
        }

        // Remove platform temporarily by platform id.
        var result =
            await _unitOfWork.PlatformFeature.RemovePlatformTemporarilyByPlatformId.Command.RemovePlatformTemporarilyByPlatformIdCommandAsync(
                platformId: request.PlatformId,
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
                    RemovePlatformTemporarilyByPlatformIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new()
        {
            StatusCode = RemovePlatformTemporarilyByPlatformIdResponseStatusCode.OPERATION_SUCCESS
        };
    }
}
