using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;

namespace FuDever.Application.Features.Department.RemoveDepartmentTemporarilyByDepartmentId;

/// <summary>
///     Remove department temporarily by department id request handler.
/// </summary>
internal sealed class RemoveDepartmentTemporarilyByDepartmentIdRequestHandler
    : IRequestHandler<
        RemoveDepartmentTemporarilyByDepartmentIdRequest,
        RemoveDepartmentTemporarilyByDepartmentIdResponse
    >
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RemoveDepartmentTemporarilyByDepartmentIdRequestHandler(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
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
    public async Task<RemoveDepartmentTemporarilyByDepartmentIdResponse> Handle(
        RemoveDepartmentTemporarilyByDepartmentIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is department found by department id.
        var isDepartmentFound =
            await _unitOfWork.DepartmentFeature.RemoveDepartmentTemporarilyByDepartmentId.Query.IsDepartmentFoundByDepartmentIdQueryAsync(
                departmentId: request.DepartmentId,
                cancellationToken: cancellationToken
            );

        // Department is not found by department id.
        if (!isDepartmentFound)
        {
            return new()
            {
                StatusCode =
                    RemoveDepartmentTemporarilyByDepartmentIdResponseStatusCode.DEPARTMENT_IS_NOT_FOUND
            };
        }

        // Is department temporarily removed by department id.
        var isDepartmentTemporarilyRemoved =
            await _unitOfWork.DepartmentFeature.RemoveDepartmentTemporarilyByDepartmentId.Query.IsDepartmentTemporarilyRemovedByDepartmentIdQueryAsync(
                departmentId: request.DepartmentId,
                cancellationToken: cancellationToken
            );

        // Department is already temporarily removed by department id.
        if (isDepartmentTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    RemoveDepartmentTemporarilyByDepartmentIdResponseStatusCode.DEPARTMENT_IS_ALREADY_TEMPORARILY_REMOVED
            };
        }

        // Remove department temporarily by department id.
        var result =
            await _unitOfWork.DepartmentFeature.RemoveDepartmentTemporarilyByDepartmentId.Command.RemoveDepartmentTemporarilyByDepartmentIdCommandAsync(
                departmentId: request.DepartmentId,
                removedAt: DateTime.UtcNow,
                removedBy: Guid.Parse(
                    input: _httpContextAccessor.HttpContext.User.FindFirstValue(
                        claimType: JwtRegisteredClaimNames.Sub
                    )
                ),
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode =
                    RemoveDepartmentTemporarilyByDepartmentIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new()
        {
            StatusCode =
                RemoveDepartmentTemporarilyByDepartmentIdResponseStatusCode.OPERATION_SUCCESS
        };
    }
}
