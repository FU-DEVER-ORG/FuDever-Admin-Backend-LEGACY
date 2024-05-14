using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Caching;
using MediatR;

namespace FuDever.Application.Features.Auth.ResendUserRegistrationConfirmedEmail.Middlewares;

/// <summary>
///     Resend user registration confirmed email request caching middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 2)]
internal sealed class ResendUserRegistrationConfirmedEmailCachingMiddleware
    : IPipelineBehavior<
        ResendUserRegistrationConfirmedEmailRequest,
        ResendUserRegistrationConfirmedEmailResponse
    >,
        IResendUserRegistrationConfirmedEmailMiddleware
{
    private readonly ICacheHandler _cacheHandler;

    public ResendUserRegistrationConfirmedEmailCachingMiddleware(ICacheHandler cacheHandler)
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
    public async Task<ResendUserRegistrationConfirmedEmailResponse> Handle(
        ResendUserRegistrationConfirmedEmailRequest request,
        RequestHandlerDelegate<ResendUserRegistrationConfirmedEmailResponse> next,
        CancellationToken cancellationToken
    )
    {
        // Cache is not enable.
        if (request.CacheExpiredTime == default)
        {
            return await next();
        }

        var cachedKey =
            $"{nameof(ResendUserRegistrationConfirmedEmailRequest)}_param_{request.Username}";

        // Retrieve from cache.
        var cacheModel = await _cacheHandler.GetAsync<ResendUserRegistrationConfirmedEmailResponse>(
            key: cachedKey,
            cancellationToken: cancellationToken
        );

        // Cache value does not exist.
        if (
            !Equals(
                objA: cacheModel,
                objB: AppCacheModel<ResendUserRegistrationConfirmedEmailResponse>.NotFound
            )
        )
        {
            return cacheModel.Value;
        }

        var response = await next();

        if (
            response.StatusCode
                != ResendUserRegistrationConfirmedEmailResponseStatusCode.OPERATION_SUCCESS
            || response.StatusCode
                != ResendUserRegistrationConfirmedEmailResponseStatusCode.SENDING_USER_CONFIRMATION_MAIL_FAIL
        )
        {
            // Caching the return value.
            await _cacheHandler.SetAsync(
                key: cachedKey,
                value: response,
                new()
                {
                    AbsoluteExpiration = DateTimeOffset.UtcNow.AddSeconds(
                        seconds: request.CacheExpiredTime
                    )
                },
                cancellationToken: cancellationToken
            );
        }

        return response;
    }
}
