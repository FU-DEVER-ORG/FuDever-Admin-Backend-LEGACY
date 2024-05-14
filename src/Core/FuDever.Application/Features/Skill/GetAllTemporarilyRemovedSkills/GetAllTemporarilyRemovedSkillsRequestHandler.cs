using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Skill.GetAllTemporarilyRemovedSkills;

/// <summary>
///     Get all temporarily removed skills request handler.
/// </summary>
internal sealed class GetAllTemporarilyRemovedSkillsRequestHandler
    : IRequestHandler<GetAllTemporarilyRemovedSkillsRequest, GetAllTemporarilyRemovedSkillsResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTemporarilyRemovedSkillsRequestHandler(IUnitOfWork unitOfWork)
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
    ///     A task containing the boolean result.
    /// </returns>
    public async Task<GetAllTemporarilyRemovedSkillsResponse> Handle(
        GetAllTemporarilyRemovedSkillsRequest request,
        CancellationToken cancellationToken
    )
    {
        // Get all temporarily removed skills.
        var foundTemporarilyRemovedSkills =
            await _unitOfWork.SkillFeature.GetAllTemporarilyRemovedSkills.Query.GetAllTemporarilyRemovedSkillsQueryAsync(
                cancellationToken: cancellationToken
            );

        // Project result to response.
        return new()
        {
            StatusCode = GetAllTemporarilyRemovedSkillsResponseStatusCode.OPERATION_SUCCESS,
            FoundTemporarilyRemovedSkills = foundTemporarilyRemovedSkills.Select(
                selector: foundSkill =>
                {
                    return new GetAllTemporarilyRemovedSkillsResponse.Skill()
                    {
                        SkillId = foundSkill.Id,
                        SkillName = foundSkill.Name,
                        SkillRemovedAt = foundSkill.RemovedAt,
                        SkillRemovedBy = foundSkill.RemovedBy
                    };
                }
            )
        };
    }
}
