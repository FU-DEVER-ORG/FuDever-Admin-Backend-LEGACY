using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Major.GetAllMajors;
using FuDever.Application.Features.Major.GetAllMajorsByMajorName;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Caching;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Major.UpdateMajorByMajorId.Middlewares;

/// <summary>
///     Update major by major id
///     request caching middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 3)]
internal sealed class UpdateMajorByMajorIdCachingMiddleware
    : IPipelineBehavior<UpdateMajorByMajorIdRequest, UpdateMajorByMajorIdResponse>,
        IUpdateMajorByMajorIdMiddleware
{
    private readonly ICacheHandler _cacheHandler;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMajorByMajorIdCachingMiddleware(ICacheHandler cacheHandler, IUnitOfWork unitOfWork)
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
    public async Task<UpdateMajorByMajorIdResponse> Handle(
        UpdateMajorByMajorIdRequest request,
        RequestHandlerDelegate<UpdateMajorByMajorIdResponse> next,
        CancellationToken cancellationToken
    )
    {
        // Finding current major by major id.
        var foundMajor =
            await _unitOfWork.MajorFeature.UpdateMajorByMajorId.Query.FindMajorByMajorIdForCacheClearing(
                majorId: request.MajorId,
                cancellationToken: cancellationToken
            );

        // Major is found by major id.
        if (!Equals(objA: foundMajor, objB: default))
        {
            await _cacheHandler.RemoveAsync(
                key: $"{nameof(GetAllMajorsByMajorNameRequest)}_param_{foundMajor.Name.ToLower()}",
                cancellationToken: cancellationToken
            );
        }

        var response = await next();

        if (response.StatusCode == UpdateMajorByMajorIdResponseStatusCode.OPERATION_SUCCESS)
        {
            await Task.WhenAll(
                _cacheHandler.RemoveAsync(
                    key: $"{nameof(GetAllMajorsByMajorNameRequest)}_param_{request.NewMajorName.ToLower()}",
                    cancellationToken: cancellationToken
                ),
                _cacheHandler.RemoveAsync(
                    key: nameof(GetAllMajorsRequest),
                    cancellationToken: cancellationToken
                )
            );
        }

        return response;
    }
}
