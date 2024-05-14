using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Skill.GetAllSkillsBySkillName;

/// <summary>
///     Get all skills by name request handler.
/// </summary>
internal sealed class GetAllSkillsBySkillNameRequestHandler
    : IRequestHandler<GetAllSkillsBySkillNameRequest, GetAllSkillsBySkillNameResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSkillsBySkillNameRequestHandler(IUnitOfWork unitOfWork)
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
    /// </param>
    /// <returns>
    ///     A task containing the boolean result.
    /// </returns>
    public async Task<GetAllSkillsBySkillNameResponse> Handle(
        GetAllSkillsBySkillNameRequest request,
        CancellationToken cancellationToken
    )
    {
        // Get all skills by name.
        var foundSkills =
            await _unitOfWork.SkillFeature.GetAllSkillsBySkillName.Query.GetAllSkillsBySkillNameQueryAsync(
                skillName: request.SkillName,
                cancellationToken: cancellationToken
            );

        return new()
        {
            StatusCode = GetAllSkillsBySkillNameResponseStatusCode.OPERATION_SUCCESS,
            FoundSkills = foundSkills.Select(selector: foundSkill =>
            {
                return new GetAllSkillsBySkillNameResponse.Skill()
                {
                    SkillId = foundSkill.Id,
                    SkillName = foundSkill.Name
                };
            }),
        };
    }
}
