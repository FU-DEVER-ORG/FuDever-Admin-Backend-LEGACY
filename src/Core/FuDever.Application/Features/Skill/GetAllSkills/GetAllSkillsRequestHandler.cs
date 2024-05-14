using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Skill.GetAllSkills;

/// <summary>
///     Get all skills request handler.
/// </summary>
internal sealed class GetAllSkillsRequestHandler
    : IRequestHandler<GetAllSkillsRequest, GetAllSkillsResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSkillsRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<GetAllSkillsResponse> Handle(
        GetAllSkillsRequest request,
        CancellationToken cancellationToken
    )
    {
        // Get all non temporarily removed skills.
        var foundSkills =
            await _unitOfWork.SkillFeature.GetAllSkills.Query.GetAllNonTemporarilyRemovedSkillsQueryAsync(
                cancellationToken: cancellationToken
            );

        // Project result to response.
        return new()
        {
            StatusCode = GetAllSkillsResponseStatusCode.OPERATION_SUCCESS,
            FoundSkills = foundSkills.Select(selector: foundSkill =>
            {
                return new GetAllSkillsResponse.Skill()
                {
                    SkillId = foundSkill.Id,
                    SkillName = foundSkill.Name
                };
            })
        };
    }
}
