using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Hobby.GetAllHobbies;
using FuDever.Application.Features.Hobby.GetAllHobbiesByHobbyName;
using FuDever.Application.Features.Hobby.GetAllTemporarilyRemovedHobbies;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Caching;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Hobby.RemoveHobbyTemporarilyByHobbyId.Middlewares;

/// <summary>
///     Remove hobby temporarily by
///     hobby id caching middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 3)]
internal sealed class RemoveHobbyTemporarilyByHobbyIdCachingMiddleware
    : IPipelineBehavior<
        RemoveHobbyTemporarilyByHobbyIdRequest,
        RemoveHobbyTemporarilyByHobbyIdResponse
    >,
        IRemoveHobbyTemporarilyByHobbyIdMiddleware
{
    private readonly ICacheHandler _cacheHandler;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveHobbyTemporarilyByHobbyIdCachingMiddleware(
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
    public async Task<RemoveHobbyTemporarilyByHobbyIdResponse> Handle(
        RemoveHobbyTemporarilyByHobbyIdRequest request,
        RequestHandlerDelegate<RemoveHobbyTemporarilyByHobbyIdResponse> next,
        CancellationToken cancellationToken
    )
    {
        var response = await next();

        if (
            response.StatusCode
            == RemoveHobbyTemporarilyByHobbyIdResponseStatusCode.OPERATION_SUCCESS
        )
        {
            var foundHobby =
                await _unitOfWork.HobbyFeature.RemoveHobbyTemporarilyByHobbyId.Query.FindHobbyByHobbyIdForCacheClearing(
                    hobbyId: request.HobbyId,
                    cancellationToken: cancellationToken
                );

            await Task.WhenAll(
                _cacheHandler.RemoveAsync(
                    key: $"{nameof(GetAllHobbiesByHobbyNameRequest)}_param_{foundHobby.Name.ToLower()}",
                    cancellationToken: cancellationToken
                ),
                _cacheHandler.RemoveAsync(
                    key: nameof(GetAllHobbiesRequest),
                    cancellationToken: cancellationToken
                ),
                _cacheHandler.RemoveAsync(
                    key: nameof(GetAllTemporarilyRemovedHobbiesRequest),
                    cancellationToken: cancellationToken
                )
            );
        }

        return response;
    }
}
