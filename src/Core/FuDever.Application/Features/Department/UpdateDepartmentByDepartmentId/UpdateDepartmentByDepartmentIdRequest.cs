using System;
using FuDever.Application.Features.Department.UpdateDepartmentByDepartmentId.Middlewares;
using MediatR;

namespace FuDever.Application.Features.Department.UpdateDepartmentByDepartmentId;

/// <summary>
///     Update department by department id request.
/// </summary>
public sealed class UpdateDepartmentByDepartmentIdRequest
    : IRequest<UpdateDepartmentByDepartmentIdResponse>,
        IUpdateDepartmentByDepartmentIdMiddleware
{
    public Guid DepartmentId { get; init; }

    public string NewDepartmentName { get; init; }
}
