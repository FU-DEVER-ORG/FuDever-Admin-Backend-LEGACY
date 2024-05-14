using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Department.GetAllDepartments;
using FuDever.Application.Features.Department.GetAllDepartmentsByDepartmentName;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Caching;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Department.UpdateDepartmentByDepartmentId.Middlewares;

/// <summary>
///     Update department by department id
///     request caching middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 3)]
internal sealed class UpdateDepartmentByDepartmentIdCachingMiddleware
    : IPipelineBehavior<
        UpdateDepartmentByDepartmentIdRequest,
        UpdateDepartmentByDepartmentIdResponse
    >,
        IUpdateDepartmentByDepartmentIdMiddleware
{
    private readonly ICacheHandler _cacheHandler;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDepartmentByDepartmentIdCachingMiddleware(
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
    public async Task<UpdateDepartmentByDepartmentIdResponse> Handle(
        UpdateDepartmentByDepartmentIdRequest request,
        RequestHandlerDelegate<UpdateDepartmentByDepartmentIdResponse> next,
        CancellationToken cancellationToken
    )
    {
        // Finding current department by department id.
        var foundDepartment =
            await _unitOfWork.DepartmentFeature.UpdateDepartmentByDepartmentId.Query.FindDepartmentByDepartmentIdForCacheClearing(
                departmentId: request.DepartmentId,
                cancellationToken: cancellationToken
            );

        // Department is found by department id.
        if (!Equals(objA: foundDepartment, objB: default))
        {
            await _cacheHandler.RemoveAsync(
                key: $"{nameof(GetAllDepartmentsByDepartmentNameRequest)}_param_{foundDepartment.Name.ToLower()}",
                cancellationToken: cancellationToken
            );
        }

        var response = await next();

        if (
            response.StatusCode
            == UpdateDepartmentByDepartmentIdResponseStatusCode.OPERATION_SUCCESS
        )
        {
            await Task.WhenAll(
                _cacheHandler.RemoveAsync(
                    key: $"{nameof(GetAllDepartmentsByDepartmentNameRequest)}_param_{request.NewDepartmentName.ToLower()}",
                    cancellationToken: cancellationToken
                ),
                _cacheHandler.RemoveAsync(
                    key: nameof(GetAllDepartmentsRequest),
                    cancellationToken: cancellationToken
                )
            );
        }

        return response;
    }
}
