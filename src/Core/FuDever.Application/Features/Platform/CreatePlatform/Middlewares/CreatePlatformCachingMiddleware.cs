using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Platform.GetAllPlatforms;
using FuDever.Application.Features.Platform.GetAllPlatformsByPlatformName;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Caching;
using MediatR;

namespace FuDever.Application.Features.Platform.CreatePlatform.Middlewares;

/// <summary>
///     Create platform request caching middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 3)]
internal sealed class CreatePlatformCachingMiddleware
    : IPipelineBehavior<CreatePlatformRequest, CreatePlatformResponse>,
        ICreatePlatformMiddleware
{
    private readonly ICacheHandler _cacheHandler;

    public CreatePlatformCachingMiddleware(ICacheHandler cacheHandler)
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
    public async Task<CreatePlatformResponse> Handle(
        CreatePlatformRequest request,
        RequestHandlerDelegate<CreatePlatformResponse> next,
        CancellationToken cancellationToken
    )
    {
        var response = await next();

        if (response.StatusCode == CreatePlatformResponseStatusCode.OPERATION_SUCCESS)
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
