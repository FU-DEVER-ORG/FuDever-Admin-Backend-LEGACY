using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Department.GetAllTemporarilyRemovedDepartments;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Caching;
using MediatR;

namespace FuDever.Application.Features.Department.RemoveDepartmentPermanentlyByDepartmentId.Middlewares;

/// <summary>
///     Remove permanently department by
///     department id request caching middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 3)]
internal sealed class RemoveDepartmentPermanentlyByDepartmentIdCachingMiddleware
    : IPipelineBehavior<
        RemoveDepartmentPermanentlyByDepartmentIdRequest,
        RemoveDepartmentPermanentlyByDepartmentIdResponse
    >,
        IRemoveDepartmentPermanentlyByDepartmentIdMiddleware
{
    private readonly ICacheHandler _cacheHandler;

    public RemoveDepartmentPermanentlyByDepartmentIdCachingMiddleware(ICacheHandler cacheHandler)
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
    public async Task<RemoveDepartmentPermanentlyByDepartmentIdResponse> Handle(
        RemoveDepartmentPermanentlyByDepartmentIdRequest request,
        RequestHandlerDelegate<RemoveDepartmentPermanentlyByDepartmentIdResponse> next,
        CancellationToken cancellationToken
    )
    {
        var response = await next();

        if (
            response.StatusCode
            == RemoveDepartmentPermanentlyByDepartmentIdResponseStatusCode.OPERATION_SUCCESS
        )
        {
            await _cacheHandler.RemoveAsync(
                key: nameof(GetAllTemporarilyRemovedDepartmentsRequest),
                cancellationToken: cancellationToken
            );
        }

        return response;
    }
}
