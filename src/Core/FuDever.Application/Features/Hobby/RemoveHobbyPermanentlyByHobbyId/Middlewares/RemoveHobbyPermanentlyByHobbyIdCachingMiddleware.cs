using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Hobby.GetAllTemporarilyRemovedHobbies;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Caching;
using MediatR;

namespace FuDever.Application.Features.Hobby.RemoveHobbyPermanentlyByHobbyId.Middlewares;

/// <summary>
///     Remove hobby permanently by
///     hobby id caching middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 3)]
internal sealed class RemoveHobbyPermanentlyByHobbyIdCachingMiddleware
    : IPipelineBehavior<
        RemoveHobbyPermanentlyByHobbyIdRequest,
        RemoveHobbyPermanentlyByHobbyIdResponse
    >,
        IRemoveHobbyPermanentlyByHobbyIdMiddleware
{
    private readonly ICacheHandler _cacheHandler;

    public RemoveHobbyPermanentlyByHobbyIdCachingMiddleware(ICacheHandler cacheHandler)
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
    public async Task<RemoveHobbyPermanentlyByHobbyIdResponse> Handle(
        RemoveHobbyPermanentlyByHobbyIdRequest request,
        RequestHandlerDelegate<RemoveHobbyPermanentlyByHobbyIdResponse> next,
        CancellationToken cancellationToken
    )
    {
        var response = await next();

        if (
            response.StatusCode
            == RemoveHobbyPermanentlyByHobbyIdResponseStatusCode.OPERATION_SUCCESS
        )
        {
            await _cacheHandler.RemoveAsync(
                key: nameof(GetAllTemporarilyRemovedHobbiesRequest),
                cancellationToken: cancellationToken
            );
        }

        return response;
    }
}
