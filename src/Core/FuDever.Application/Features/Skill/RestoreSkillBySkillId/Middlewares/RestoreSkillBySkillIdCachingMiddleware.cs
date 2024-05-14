using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Skill.GetAllSkills;
using FuDever.Application.Features.Skill.GetAllSkillsBySkillName;
using FuDever.Application.Features.Skill.GetAllTemporarilyRemovedSkills;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Caching;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Skill.RestoreSkillBySkillId.Middlewares;

/// <summary>
///     Restore skill by skill
///     id request caching middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 3)]
internal sealed class RestoreSkillBySkillIdCachingMiddleware
    : IPipelineBehavior<RestoreSkillBySkillIdRequest, RestoreSkillBySkillIdResponse>,
        IRestoreSkillBySkillIdMiddleware
{
    private readonly ICacheHandler _cacheHandler;
    private readonly IUnitOfWork _unitOfWork;

    public RestoreSkillBySkillIdCachingMiddleware(
        ICacheHandler cacheHandler,
        IUnitOfWork unitOfWork
    )
    {
        _cacheHandler = cacheHandler;
        _unitOfWork = unitOfWork;
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
    public async Task<RestoreSkillBySkillIdResponse> Handle(
        RestoreSkillBySkillIdRequest request,
        RequestHandlerDelegate<RestoreSkillBySkillIdResponse> next,
        CancellationToken cancellationToken
    )
    {
        var response = await next();

        if (response.StatusCode == RestoreSkillBySkillIdResponseStatusCode.OPERATION_SUCCESS)
        {
            var foundSkill =
                await _unitOfWork.SkillFeature.RestoreSkillBySkillId.Query.FindSkillBySkillIdForCacheClearing(
                    skillId: request.SkillId,
                    cancellationToken: cancellationToken
                );

            await Task.WhenAll(
                _cacheHandler.RemoveAsync(
                    key: $"{nameof(GetAllSkillsBySkillNameRequest)}_param_{foundSkill.Name.ToLower()}",
                    cancellationToken: cancellationToken
                ),
                _cacheHandler.RemoveAsync(
                    key: nameof(GetAllSkillsRequest),
                    cancellationToken: cancellationToken
                ),
                _cacheHandler.RemoveAsync(
                    key: nameof(GetAllTemporarilyRemovedSkillsRequest),
                    cancellationToken: cancellationToken
                )
            );
        }

        return response;
    }
}
