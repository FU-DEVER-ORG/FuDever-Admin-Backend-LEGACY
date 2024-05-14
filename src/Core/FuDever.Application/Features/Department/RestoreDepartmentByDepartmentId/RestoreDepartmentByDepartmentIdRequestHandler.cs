using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Data;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Department.RestoreDepartmentByDepartmentId;

/// <summary>
///     Restore department by department id request handler.
/// </summary>
internal sealed class RestoreDepartmentByDepartmentIdRequestHandler
    : IRequestHandler<
        RestoreDepartmentByDepartmentIdRequest,
        RestoreDepartmentByDepartmentIdResponse
    >
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDbMinTimeHandler _dbMinTimeHandler;

    public RestoreDepartmentByDepartmentIdRequestHandler(
        IUnitOfWork unitOfWork,
        IDbMinTimeHandler dbMinTimeHandler
    )
    {
        _unitOfWork = unitOfWork;
        _dbMinTimeHandler = dbMinTimeHandler;
    }

    /// <summary>
    ///     Entry of new request handler.
    /// </summary>
    /// <param name="request">
    ///     Request model.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used for notifying system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     A task containing the response.
    /// </returns>
    public async Task<RestoreDepartmentByDepartmentIdResponse> Handle(
        RestoreDepartmentByDepartmentIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is department found by department id.
        var isDepartmentFoundByDepartmentId =
            await _unitOfWork.DepartmentFeature.RestoreDepartmentByDepartmentId.Query.IsDepartmentFoundByDepartmentIdQueryAsync(
                departmentId: request.DepartmentId,
                cancellationToken: cancellationToken
            );

        // Department is not found by department id.
        if (!isDepartmentFoundByDepartmentId)
        {
            return new()
            {
                StatusCode =
                    RestoreDepartmentByDepartmentIdResponseStatusCode.DEPARTMENT_IS_NOT_FOUND
            };
        }

        // Is department temporarily removed by department id.
        var isDepartmentTemporarilyRemoved =
            await _unitOfWork.DepartmentFeature.RestoreDepartmentByDepartmentId.Query.IsDepartmentTemporarilyRemovedByDepartmentIdQueryAsync(
                departmentId: request.DepartmentId,
                cancellationToken: cancellationToken
            );

        // Department is not temporarily removed by department id.
        if (!isDepartmentTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    RestoreDepartmentByDepartmentIdResponseStatusCode.DEPARTMENT_IS_NOT_TEMPORARILY_REMOVED
            };
        }

        // Remove department permanently by department id.
        var result =
            await _unitOfWork.DepartmentFeature.RestoreDepartmentByDepartmentId.Command.RestoreDepartmentByDepartmentIdCommandAsync(
                departmentId: request.DepartmentId,
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode =
                    RestoreDepartmentByDepartmentIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new()
        {
            StatusCode = RestoreDepartmentByDepartmentIdResponseStatusCode.OPERATION_SUCCESS
        };
    }
}
