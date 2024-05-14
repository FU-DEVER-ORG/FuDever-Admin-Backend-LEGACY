using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Department.GetAllTemporarilyRemovedDepartments;

/// <summary>
///     Get all temporarily removed departments request handler.
/// </summary>
internal sealed class GetAllTemporarilyRemovedDepartmentsRequestHandler
    : IRequestHandler<
        GetAllTemporarilyRemovedDepartmentsRequest,
        GetAllTemporarilyRemovedDepartmentsResponse
    >
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTemporarilyRemovedDepartmentsRequestHandler(IUnitOfWork unitOfWork)
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
    ///     A task containing the boolean result.
    /// </returns>
    public async Task<GetAllTemporarilyRemovedDepartmentsResponse> Handle(
        GetAllTemporarilyRemovedDepartmentsRequest request,
        CancellationToken cancellationToken
    )
    {
        // Get all temporarily removed departments.
        var foundTemporarilyRemovedDepartments =
            await _unitOfWork.DepartmentFeature.GetAllTemporarilyRemovedDepartments.Query.GetAllTemporarilyRemovedDepartmentsQueryAsync(
                cancellationToken: cancellationToken
            );

        // Project result to response.
        return new()
        {
            StatusCode = GetAllTemporarilyRemovedDepartmentsResponseStatusCode.OPERATION_SUCCESS,
            FoundTemporarilyRemovedDepartments = foundTemporarilyRemovedDepartments.Select(
                selector: foundDepartment =>
                {
                    return new GetAllTemporarilyRemovedDepartmentsResponse.Department()
                    {
                        DepartmentId = foundDepartment.Id,
                        DepartmentName = foundDepartment.Name,
                        DepartmentRemovedAt = foundDepartment.RemovedAt,
                        DepartmentRemovedBy = foundDepartment.RemovedBy
                    };
                }
            )
        };
    }
}
