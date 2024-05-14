using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Department.RemoveDepartmentPermanentlyByDepartmentId;

/// <summary>
///     Remove department permanently by department id request handler.
/// </summary>
internal sealed class RemoveDepartmentPermanentlyByDepartmentIdRequestHandler
    : IRequestHandler<
        RemoveDepartmentPermanentlyByDepartmentIdRequest,
        RemoveDepartmentPermanentlyByDepartmentIdResponse
    >
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveDepartmentPermanentlyByDepartmentIdRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<RemoveDepartmentPermanentlyByDepartmentIdResponse> Handle(
        RemoveDepartmentPermanentlyByDepartmentIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is department found by department id.
        var isDepartmentFoundByDepartmentId =
            await _unitOfWork.DepartmentFeature.RemoveDepartmentPermanentlyByDepartmentId.Query.IsDepartmentFoundByDepartmentIdQueryAsync(
                departmentId: request.DepartmentId,
                cancellationToken: cancellationToken
            );

        // Department is not found by department id.
        if (!isDepartmentFoundByDepartmentId)
        {
            return new()
            {
                StatusCode =
                    RemoveDepartmentPermanentlyByDepartmentIdResponseStatusCode.DEPARTMENT_IS_NOT_FOUND
            };
        }

        // Is department temporarily removed by department id.
        var isDepartmentTemporarilyRemoved =
            await _unitOfWork.DepartmentFeature.RemoveDepartmentPermanentlyByDepartmentId.Query.IsDepartmentTemporarilyRemovedByDepartmentIdQueryAsync(
                departmentId: request.DepartmentId,
                cancellationToken: cancellationToken
            );

        // Department is not temporarily removed by department id.
        if (!isDepartmentTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    RemoveDepartmentPermanentlyByDepartmentIdResponseStatusCode.DEPARTMENT_IS_NOT_TEMPORARILY_REMOVED
            };
        }

        // Remove department permanently by department id.
        var result =
            await _unitOfWork.DepartmentFeature.RemoveDepartmentPermanentlyByDepartmentId.Command.RemoveDepartmentPermanentlyByDepartmentIdCommandAsync(
                departmentId: request.DepartmentId,
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode =
                    RemoveDepartmentPermanentlyByDepartmentIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new()
        {
            StatusCode =
                RemoveDepartmentPermanentlyByDepartmentIdResponseStatusCode.OPERATION_SUCCESS
        };
    }
}
