using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;

namespace FuDever.Application.Features.Skill.RemoveSkillTemporarilyBySkillId;

/// <summary>
///     Remove skill temporarily by skill id request handler.
/// </summary>
internal sealed class RemoveSkillTemporarilyBySkillIdRequestHandler
    : IRequestHandler<
        RemoveSkillTemporarilyBySkillIdRequest,
        RemoveSkillTemporarilyBySkillIdResponse
    >
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RemoveSkillTemporarilyBySkillIdRequestHandler(
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
    public async Task<RemoveSkillTemporarilyBySkillIdResponse> Handle(
        RemoveSkillTemporarilyBySkillIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is skill found by skill id.
        var isSkillFound =
            await _unitOfWork.SkillFeature.RemoveSkillTemporarilyBySkillId.Query.IsSkillFoundBySkillIdQueryAsync(
                skillId: request.SkillId,
                cancellationToken: cancellationToken
            );

        // Skill is not found by skill id.
        if (!isSkillFound)
        {
            return new()
            {
                StatusCode = RemoveSkillTemporarilyBySkillIdResponseStatusCode.SKILL_IS_NOT_FOUND
            };
        }

        // Is skill temporarily removed by skill id.
        var isSkillTemporarilyRemoved =
            await _unitOfWork.SkillFeature.RemoveSkillTemporarilyBySkillId.Query.IsSkillTemporarilyRemovedBySkillIdQueryAsync(
                skillId: request.SkillId,
                cancellationToken: cancellationToken
            );

        // Skill is already temporarily removed by skill id.
        if (isSkillTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    RemoveSkillTemporarilyBySkillIdResponseStatusCode.SKILL_IS_ALREADY_TEMPORARILY_REMOVED
            };
        }

        // Remove skill temporarily by skill id.
        var result =
            await _unitOfWork.SkillFeature.RemoveSkillTemporarilyBySkillId.Command.RemoveSkillTemporarilyBySkillIdCommandAsync(
                skillId: request.SkillId,
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
                    RemoveSkillTemporarilyBySkillIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new()
        {
            StatusCode = RemoveSkillTemporarilyBySkillIdResponseStatusCode.OPERATION_SUCCESS
        };
    }
}
