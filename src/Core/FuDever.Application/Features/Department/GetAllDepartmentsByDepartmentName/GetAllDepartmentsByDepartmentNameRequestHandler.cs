using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Department.GetAllDepartmentsByDepartmentName;

/// <summary>
///     Get all departments by department name request handler.
/// </summary>
internal sealed class GetAllDepartmentsByDepartmentNameRequestHandler
    : IRequestHandler<
        GetAllDepartmentsByDepartmentNameRequest,
        GetAllDepartmentsByDepartmentNameResponse
    >
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllDepartmentsByDepartmentNameRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<GetAllDepartmentsByDepartmentNameResponse> Handle(
        GetAllDepartmentsByDepartmentNameRequest request,
        CancellationToken cancellationToken
    )
    {
        // Get all departments by department name.
        var foundDepartments =
            await _unitOfWork.DepartmentFeature.GetAllDepartmentsByDepartmentName.Query.GetAllDepartmentsByDepartmentNameQueryAsync(
                departmentName: request.DepartmentName,
                cancellationToken: cancellationToken
            );

        // Project result to response.
        return new()
        {
            StatusCode = GetAllDepartmentsByDepartmentNameResponseStatusCode.OPERATION_SUCCESS,
            FoundDepartments = foundDepartments.Select(selector: foundDepartment =>
            {
                return new GetAllDepartmentsByDepartmentNameResponse.Department()
                {
                    DepartmentId = foundDepartment.Id,
                    DepartmentName = foundDepartment.Name
                };
            })
        };
    }
}
