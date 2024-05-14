using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Department.UpdateDepartmentByDepartmentId;

/// <summary>
///     Update department by department id request handler.
/// </summary>
internal sealed class UpdateDepartmentByDepartmentIdRequestHandler
    : IRequestHandler<UpdateDepartmentByDepartmentIdRequest, UpdateDepartmentByDepartmentIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDepartmentByDepartmentIdRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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
    public async Task<UpdateDepartmentByDepartmentIdResponse> Handle(
        UpdateDepartmentByDepartmentIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is department found by department id.
        var isDepartmentFoundByDepartmentId =
            await _unitOfWork.DepartmentFeature.UpdateDepartmentByDepartmentId.Query.IsDepartmentFoundByDepartmentIdQueryAsync(
                departmentId: request.DepartmentId,
                cancellationToken: cancellationToken
            );

        // Department is not found by department id.
        if (!isDepartmentFoundByDepartmentId)
        {
            return new()
            {
                StatusCode =
                    UpdateDepartmentByDepartmentIdResponseStatusCode.DEPARTMENT_IS_NOT_FOUND
            };
        }

        // Is department temporarily removed by department id.
        var isDepartmentTemporarilyRemoved =
            await _unitOfWork.DepartmentFeature.UpdateDepartmentByDepartmentId.Query.IsDepartmentTemporarilyRemovedByDepartmentIdQueryAsync(
                departmentId: request.DepartmentId,
                cancellationToken: cancellationToken
            );

        // Department is already temporarily removed by department id.
        if (isDepartmentTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    UpdateDepartmentByDepartmentIdResponseStatusCode.DEPARTMENT_IS_ALREADY_TEMPORARILY_REMOVED
            };
        }

        // Is department with the same department name found.
        var isDepartmentWithTheSameNameFound =
            await _unitOfWork.DepartmentFeature.UpdateDepartmentByDepartmentId.Query.IsDepartmentWithTheSameNameFoundByDepartmentNameQueryAsync(
                newDepartmentName: request.NewDepartmentName,
                cancellationToken: cancellationToken
            );

        // Department with the same department name is found.
        if (isDepartmentWithTheSameNameFound)
        {
            return new()
            {
                StatusCode =
                    UpdateDepartmentByDepartmentIdResponseStatusCode.DEPARTMENT_ALREADY_EXISTS
            };
        }

        // Update department by department id.
        var result =
            await _unitOfWork.DepartmentFeature.UpdateDepartmentByDepartmentId.Command.UpdateDepartmentByDepartmentIdCommandAsync(
                departmentId: request.DepartmentId,
                newDepartmentName: request.NewDepartmentName,
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode =
                    UpdateDepartmentByDepartmentIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new()
        {
            StatusCode = UpdateDepartmentByDepartmentIdResponseStatusCode.OPERATION_SUCCESS
        };
    }
}
