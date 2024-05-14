using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Commons;
using FuDever.Application.Shared.Data;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Department.CreateDepartment;

/// <summary>
///     Create department request handler.
/// </summary>
internal sealed class CreateDepartmentRequestHandler
    : IRequestHandler<CreateDepartmentRequest, CreateDepartmentResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDbMinTimeHandler _dbMinTimeHandler;

    public CreateDepartmentRequestHandler(
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
    public async Task<CreateDepartmentResponse> Handle(
        CreateDepartmentRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is department with the same department name found.
        var isDepartmentFound =
            await _unitOfWork.DepartmentFeature.CreateDepartment.Query.IsDepartmentWithTheSameNameFoundByDepartmentNameQueryAsync(
                newDepartmentName: request.NewDepartmentName,
                cancellationToken: cancellationToken
            );

        // Departments with the same department name is found.
        if (isDepartmentFound)
        {
            // Is department temporarily removed by department name.
            var isDepartmentTemporarilyRemoved =
                await _unitOfWork.DepartmentFeature.CreateDepartment.Query.IsDepartmentTemporarilyRemovedByDepartmentNameQueryAsync(
                    newDepartmentName: request.NewDepartmentName,
                    cancellationToken: cancellationToken
                );

            // Department with department name is already temporarily removed.
            if (isDepartmentTemporarilyRemoved)
            {
                return new()
                {
                    StatusCode =
                        CreateDepartmentResponseStatusCode.DEPARTMENT_IS_ALREADY_TEMPORARILY_REMOVED
                };
            }

            return new()
            {
                StatusCode = CreateDepartmentResponseStatusCode.DEPARTMENT_ALREADY_EXISTS
            };
        }

        // Create department with new department name.
        var result =
            await _unitOfWork.DepartmentFeature.CreateDepartment.Command.CreateDepartmentCommandAsync(
                newDepartment: InitNewDepartment(newDepartmentName: request.NewDepartmentName),
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode = CreateDepartmentResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new() { StatusCode = CreateDepartmentResponseStatusCode.OPERATION_SUCCESS };
    }

    #region Others
    /// <summary>
    ///     Initializes a new instance of the Department
    ///     class with the given department name.
    /// </summary>
    /// <param name="newDepartmentName">
    ///     The name of the new department.
    /// </param>
    /// <returns>
    ///     A new Department object with a unique ID,
    ///     the specified name, and default removal
    ///     information.
    /// </returns>
    private Domain.Entities.Department InitNewDepartment(string newDepartmentName)
    {
        return new()
        {
            Id = Guid.NewGuid(),
            Name = newDepartmentName,
            RemovedAt = _dbMinTimeHandler.Get(),
            RemovedBy = CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
        };
    }
    #endregion
}
