using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Data;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Skill.RestoreSkillBySkillId;

/// <summary>
///     Restore skill by skill id request handler.
/// </summary>
internal sealed class RestoreSkillBySkillIdRequestHandler
    : IRequestHandler<RestoreSkillBySkillIdRequest, RestoreSkillBySkillIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDbMinTimeHandler _dbMinTimeHandler;

    public RestoreSkillBySkillIdRequestHandler(
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
    public async Task<RestoreSkillBySkillIdResponse> Handle(
        RestoreSkillBySkillIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is skill found by skill id.
        var isSkillFoundBySkillId =
            await _unitOfWork.SkillFeature.RestoreSkillBySkillId.Query.IsSkillFoundBySkillIdQueryAsync(
                skillId: request.SkillId,
                cancellationToken: cancellationToken
            );

        // Skill is not found by skill id.
        if (!isSkillFoundBySkillId)
        {
            return new()
            {
                StatusCode = RestoreSkillBySkillIdResponseStatusCode.SKILL_IS_NOT_FOUND
            };
        }

        // Is skill temporarily removed by skill id.
        var isSkillTemporarilyRemoved =
            await _unitOfWork.SkillFeature.RestoreSkillBySkillId.Query.IsSkillTemporarilyRemovedBySkillIdQueryAsync(
                skillId: request.SkillId,
                cancellationToken: cancellationToken
            );

        // Skill is not temporarily removed by skill id.
        if (!isSkillTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    RestoreSkillBySkillIdResponseStatusCode.SKILL_IS_NOT_TEMPORARILY_REMOVED
            };
        }

        // Restore skill by skill id.
        var result =
            await _unitOfWork.SkillFeature.RestoreSkillBySkillId.Command.RestoreSkillBySkillIdCommandAsync(
                skillId: request.SkillId,
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode = RestoreSkillBySkillIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new() { StatusCode = RestoreSkillBySkillIdResponseStatusCode.OPERATION_SUCCESS };
    }
}
