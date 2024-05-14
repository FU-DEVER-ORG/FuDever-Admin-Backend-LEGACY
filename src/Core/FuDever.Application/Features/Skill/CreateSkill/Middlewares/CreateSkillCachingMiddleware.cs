using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Skill.GetAllSkills;
using FuDever.Application.Features.Skill.GetAllSkillsBySkillName;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Caching;
using MediatR;

namespace FuDever.Application.Features.Skill.CreateSkill.Middlewares;

/// <summary>
///     Create skill request caching middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 3)]
internal sealed class CreateSkillCachingMiddleware
    : IPipelineBehavior<CreateSkillRequest, CreateSkillResponse>,
        ICreateSkillMiddleware
{
    private readonly ICacheHandler _cacheHandler;

    public CreateSkillCachingMiddleware(ICacheHandler cacheHandler)
    {
        _cacheHandler = cacheHandler;
    }

    /// <summary>
    ///     Entry to middleware handler.
    /// </summary>
    /// <param name="request">
    ///     Current request object.
    /// </param>
    /// <param name="next">
    ///     Navigate to next middleware and get back response.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used for notifying system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     Response of use case.
    /// </returns>
    public async Task<CreateSkillResponse> Handle(
        CreateSkillRequest request,
        RequestHandlerDelegate<CreateSkillResponse> next,
        CancellationToken cancellationToken
    )
    {
        var response = await next();

        if (response.StatusCode == CreateSkillResponseStatusCode.OPERATION_SUCCESS)
        {
            await Task.WhenAll(
                _cacheHandler.RemoveAsync(
                    key: $"{nameof(GetAllSkillsBySkillNameRequest)}_param_{request.NewSkillName.ToLower()}",
                    cancellationToken: cancellationToken
                ),
                _cacheHandler.RemoveAsync(
                    key: nameof(GetAllSkillsRequest),
                    cancellationToken: cancellationToken
                )
            );
        }

        return response;
    }
}
