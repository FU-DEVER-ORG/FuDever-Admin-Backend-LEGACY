using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Department.GetAllDepartments;
using FuDever.Application.Features.Department.GetAllDepartmentsByDepartmentName;
using FuDever.Application.Features.Department.GetAllTemporarilyRemovedDepartments;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Caching;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Department.RemoveDepartmentTemporarilyByDepartmentId.Middlewares;

/// <summary>
///     Remove department temporarily by department
///     id request caching middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 3)]
internal sealed class RemoveDepartmentTemporarilyByDepartmentIdCachingMiddleware
    : IPipelineBehavior<
        RemoveDepartmentTemporarilyByDepartmentIdRequest,
        RemoveDepartmentTemporarilyByDepartmentIdResponse
    >,
        IRemoveDepartmentTemporarilyByDepartmentIdMiddleware
{
    private readonly ICacheHandler _cacheHandler;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveDepartmentTemporarilyByDepartmentIdCachingMiddleware(
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
    public async Task<RemoveDepartmentTemporarilyByDepartmentIdResponse> Handle(
        RemoveDepartmentTemporarilyByDepartmentIdRequest request,
        RequestHandlerDelegate<RemoveDepartmentTemporarilyByDepartmentIdResponse> next,
        CancellationToken cancellationToken
    )
    {
        var response = await next();

        if (
            response.StatusCode
            == RemoveDepartmentTemporarilyByDepartmentIdResponseStatusCode.OPERATION_SUCCESS
        )
        {
            var foundDepartment =
                await _unitOfWork.DepartmentFeature.RemoveDepartmentTemporarilyByDepartmentId.Query.FindDepartmentByDepartmentIdForCacheClearing(
                    departmentId: request.DepartmentId,
                    cancellationToken: cancellationToken
                );

            await Task.WhenAll(
                _cacheHandler.RemoveAsync(
                    key: $"{nameof(GetAllDepartmentsByDepartmentNameRequest)}_param_{foundDepartment.Name.ToLower()}",
                    cancellationToken: cancellationToken
                ),
                _cacheHandler.RemoveAsync(
                    key: nameof(GetAllDepartmentsRequest),
                    cancellationToken: cancellationToken
                ),
                _cacheHandler.RemoveAsync(
                    key: nameof(GetAllTemporarilyRemovedDepartmentsRequest),
                    cancellationToken: cancellationToken
                )
            );
        }

        return response;
    }
}
