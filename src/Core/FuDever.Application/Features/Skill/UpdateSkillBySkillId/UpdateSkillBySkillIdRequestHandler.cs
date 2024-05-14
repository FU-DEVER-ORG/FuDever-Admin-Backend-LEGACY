using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Skill.UpdateSkillBySkillId;

/// <summary>
///     Update skill by skill id request handler.
/// </summary>
internal sealed class UpdateSkillBySkillIdRequestHandler
    : IRequestHandler<UpdateSkillBySkillIdRequest, UpdateSkillBySkillIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSkillBySkillIdRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<UpdateSkillBySkillIdResponse> Handle(
        UpdateSkillBySkillIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is skill found by skill id.
        var isSkillFoundBySkillId =
            await _unitOfWork.SkillFeature.UpdateSkillBySkillId.Query.IsSkillFoundBySkillIdQueryAsync(
                skillId: request.SkillId,
                cancellationToken: cancellationToken
            );

        // Skill is not found by skill id.
        if (!isSkillFoundBySkillId)
        {
            return new() { StatusCode = UpdateSkillBySkillIdResponseStatusCode.SKILL_IS_NOT_FOUND };
        }

        // Is skill temporarily removed by skill id.
        var isSkillTemporarilyRemoved =
            await _unitOfWork.SkillFeature.UpdateSkillBySkillId.Query.IsSkillTemporarilyRemovedBySkillIdQueryAsync(
                skillId: request.SkillId,
                cancellationToken: cancellationToken
            );

        // Skill is already temporarily removed by skill id.
        if (isSkillTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    UpdateSkillBySkillIdResponseStatusCode.SKILL_IS_ALREADY_TEMPORARILY_REMOVED
            };
        }

        // Is skill with the same skill name found.
        var isSkillWithTheSameNameFound =
            await _unitOfWork.SkillFeature.UpdateSkillBySkillId.Query.IsSkillWithTheSameNameFoundBySkillNameQueryAsync(
                newSkillName: request.NewSkillName,
                cancellationToken: cancellationToken
            );

        // Skill with the same skill name is found.
        if (isSkillWithTheSameNameFound)
        {
            return new()
            {
                StatusCode = UpdateSkillBySkillIdResponseStatusCode.SKILL_ALREADY_EXISTS
            };
        }

        // Update skill by skill id.
        var result =
            await _unitOfWork.SkillFeature.UpdateSkillBySkillId.Command.UpdateSkillBySkillIdCommandAsync(
                skillId: request.SkillId,
                newSkillName: request.NewSkillName,
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode = UpdateSkillBySkillIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new() { StatusCode = UpdateSkillBySkillIdResponseStatusCode.OPERATION_SUCCESS };
    }
}
