using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Skill.RemoveSkillPermanentlyBySkillId;

/// <summary>
///     Remove skill permanently by skill id request handler.
/// </summary>
internal sealed class RemoveSkillPermanentlyBySkillIdRequestHandler
    : IRequestHandler<
        RemoveSkillPermanentlyBySkillIdRequest,
        RemoveSkillPermanentlyBySkillIdResponse
    >
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveSkillPermanentlyBySkillIdRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<RemoveSkillPermanentlyBySkillIdResponse> Handle(
        RemoveSkillPermanentlyBySkillIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is skill found by skill id.
        var isSkillFoundBySkillId =
            await _unitOfWork.SkillFeature.RemoveSkillPermanentlyBySkillId.Query.IsSkillFoundBySkillIdQueryAsync(
                skillId: request.SkillId,
                cancellationToken: cancellationToken
            );

        // Skill is not found by skill id.
        if (!isSkillFoundBySkillId)
        {
            return new()
            {
                StatusCode = RemoveSkillPermanentlyBySkillIdResponseStatusCode.SKILL_IS_NOT_FOUND
            };
        }

        // Is skill temporarily removed by skill id.
        var isSkillTemporarilyRemoved =
            await _unitOfWork.SkillFeature.RemoveSkillPermanentlyBySkillId.Query.IsSkillTemporarilyRemovedBySkillIdQueryAsync(
                skillId: request.SkillId,
                cancellationToken: cancellationToken
            );

        // Skill is not temporarily removed by skill id.
        if (!isSkillTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    RemoveSkillPermanentlyBySkillIdResponseStatusCode.SKILL_IS_NOT_TEMPORARILY_REMOVED
            };
        }

        // Remove skill permanently by skill id.
        var result =
            await _unitOfWork.SkillFeature.RemoveSkillPermanentlyBySkillId.Command.RemoveSkillPermanentlyBySkillIdCommandAsync(
                skillId: request.SkillId,
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode =
                    RemoveSkillPermanentlyBySkillIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new()
        {
            StatusCode = RemoveSkillPermanentlyBySkillIdResponseStatusCode.OPERATION_SUCCESS
        };
    }
}
