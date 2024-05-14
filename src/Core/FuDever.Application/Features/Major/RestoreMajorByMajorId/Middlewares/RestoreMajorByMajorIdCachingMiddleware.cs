using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Major.GetAllMajors;
using FuDever.Application.Features.Major.GetAllMajorsByMajorName;
using FuDever.Application.Features.Major.GetAllTemporarilyRemovedMajors;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Caching;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Major.RestoreMajorByMajorId.Middlewares;

/// <summary>
///     Restore major by major id
///     request caching middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 3)]
internal sealed class RestoreMajorByMajorIdCachingMiddleware
    : IPipelineBehavior<RestoreMajorByMajorIdRequest, RestoreMajorByMajorIdResponse>,
        IRestoreMajorByMajorIdMiddleware
{
    private readonly ICacheHandler _cacheHandler;
    private readonly IUnitOfWork _unitOfWork;

    public RestoreMajorByMajorIdCachingMiddleware(
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
    public async Task<RestoreMajorByMajorIdResponse> Handle(
        RestoreMajorByMajorIdRequest request,
        RequestHandlerDelegate<RestoreMajorByMajorIdResponse> next,
        CancellationToken cancellationToken
    )
    {
        var response = await next();

        if (response.StatusCode == RestoreMajorByMajorIdResponseStatusCode.OPERATION_SUCCESS)
        {
            var foundMajor =
                await _unitOfWork.MajorFeature.RestoreMajorByMajorId.Query.FindMajorByMajorIdForCacheClearing(
                    majorId: request.MajorId,
                    cancellationToken: cancellationToken
                );

            await Task.WhenAll(
                _cacheHandler.RemoveAsync(
                    key: $"{nameof(GetAllMajorsByMajorNameRequest)}_param_{foundMajor.Name.ToLower()}",
                    cancellationToken: cancellationToken
                ),
                _cacheHandler.RemoveAsync(
                    key: nameof(GetAllMajorsRequest),
                    cancellationToken: cancellationToken
                ),
                _cacheHandler.RemoveAsync(
                    key: nameof(GetAllTemporarilyRemovedMajorsRequest),
                    cancellationToken: cancellationToken
                )
            );
        }

        return response;
    }
}
