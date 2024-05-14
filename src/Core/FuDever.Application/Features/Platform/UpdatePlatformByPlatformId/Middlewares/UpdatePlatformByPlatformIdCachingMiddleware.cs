using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Platform.GetAllPlatforms;
using FuDever.Application.Features.Platform.GetAllPlatformsByPlatformName;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Caching;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Platform.UpdatePlatformByPlatformId.Middlewares;

/// <summary>
///     Update platform by platform id
///     request caching middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 3)]
internal sealed class UpdatePlatformByPlatformIdCachingMiddleware
    : IPipelineBehavior<UpdatePlatformByPlatformIdRequest, UpdatePlatformByPlatformIdResponse>,
        IUpdatePlatformByPlatformIdMiddleware
{
    private readonly ICacheHandler _cacheHandler;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePlatformByPlatformIdCachingMiddleware(
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
    public async Task<UpdatePlatformByPlatformIdResponse> Handle(
        UpdatePlatformByPlatformIdRequest request,
        RequestHandlerDelegate<UpdatePlatformByPlatformIdResponse> next,
        CancellationToken cancellationToken
    )
    {
        // Finding current platform by platform id.
        var foundPlatform =
            await _unitOfWork.PlatformFeature.UpdatePlatformByPlatformId.Query.FindPlatformByPlatformIdForCacheClearing(
                platformId: request.PlatformId,
                cancellationToken: cancellationToken
            );

        // Platform is found by platform id.
        if (!Equals(objA: foundPlatform, objB: default))
        {
            await _cacheHandler.RemoveAsync(
                key: $"{nameof(GetAllPlatformsByPlatformNameRequest)}_param_{foundPlatform.Name.ToLower()}",
                cancellationToken: cancellationToken
            );
        }

        var response = await next();

        if (response.StatusCode == UpdatePlatformByPlatformIdResponseStatusCode.OPERATION_SUCCESS)
        {
            await Task.WhenAll(
                _cacheHandler.RemoveAsync(
                    key: $"{nameof(GetAllPlatformsByPlatformNameRequest)}_param_{request.NewPlatformName.ToLower()}",
                    cancellationToken: cancellationToken
                ),
                _cacheHandler.RemoveAsync(
                    key: nameof(GetAllPlatformsRequest),
                    cancellationToken: cancellationToken
                )
            );
        }

        return response;
    }
}
