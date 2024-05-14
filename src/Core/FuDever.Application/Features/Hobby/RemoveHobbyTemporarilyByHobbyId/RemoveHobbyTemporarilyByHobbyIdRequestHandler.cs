using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;

namespace FuDever.Application.Features.Hobby.RemoveHobbyTemporarilyByHobbyId;

/// <summary>
///     Request handler for removing hobby temporarily by hobby id.
/// </summary>
internal sealed class RemoveHobbyTemporarilyByHobbyIdRequestHandler
    : IRequestHandler<
        RemoveHobbyTemporarilyByHobbyIdRequest,
        RemoveHobbyTemporarilyByHobbyIdResponse
    >
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RemoveHobbyTemporarilyByHobbyIdRequestHandler(
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

    public async Task<RemoveHobbyTemporarilyByHobbyIdResponse> Handle(
        RemoveHobbyTemporarilyByHobbyIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is hobby found by hobby id.
        var isHobbyFoundByHobbyId =
            await _unitOfWork.HobbyFeature.RemoveHobbyTemporarilyByHobbyId.Query.IsHobbyFoundByHobbyIdQueryAsync(
                hobbyId: request.HobbyId,
                cancellationToken: cancellationToken
            );

        // Hobby is not found by hobby id.
        if (!isHobbyFoundByHobbyId)
        {
            return new()
            {
                StatusCode = RemoveHobbyTemporarilyByHobbyIdResponseStatusCode.HOBBY_IS_NOT_FOUND
            };
        }

        // Is hobby temporarily removed by hobby id.
        var isHobbyTemporarilyRemoved =
            await _unitOfWork.HobbyFeature.RemoveHobbyTemporarilyByHobbyId.Query.IsHobbyTemporarilyRemovedByHobbyIdQueryAsync(
                hobbyId: request.HobbyId,
                cancellationToken: cancellationToken
            );

        // Hobby is already temporarily removed by hobby id.
        if (isHobbyTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    RemoveHobbyTemporarilyByHobbyIdResponseStatusCode.HOBBY_IS_ALREADY_TEMPORARILY_REMOVED
            };
        }

        // Update hobby by hobby id.
        var result =
            await _unitOfWork.HobbyFeature.RemoveHobbyTemporarilyByHobbyId.Command.RemoveHobbyTemporarilyByHobbyIdCommandAsync(
                hobbyId: request.HobbyId,
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
                    RemoveHobbyTemporarilyByHobbyIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new()
        {
            StatusCode = RemoveHobbyTemporarilyByHobbyIdResponseStatusCode.OPERATION_SUCCESS
        };
    }
}
