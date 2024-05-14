using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Department.GetAllDepartments;

/// <summary>
///     Get all department request handler.
/// </summary>
internal sealed class GetAllDepartmentsRequestHandler
    : IRequestHandler<GetAllDepartmentsRequest, GetAllDepartmentsResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllDepartmentsRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<GetAllDepartmentsResponse> Handle(
        GetAllDepartmentsRequest request,
        CancellationToken cancellationToken
    )
    {
        // Get all non temporarily removed departments.
        var foundDepartments =
            await _unitOfWork.DepartmentFeature.GetAllDepartments.Query.GetAllNonTemporarilyRemovedDepartmentsQueryAsync(
                cancellationToken: cancellationToken
            );

        // Project result to response.
        return new()
        {
            StatusCode = GetAllDepartmentsResponseStatusCode.OPERATION_SUCCESS,
            FoundDepartments = foundDepartments.Select(selector: foundDepartment =>
            {
                return new GetAllDepartmentsResponse.Department()
                {
                    DepartmentId = foundDepartment.Id,
                    DepartmentName = foundDepartment.Name
                };
            })
        };
    }
}
