namespace FuDever.Domain.Repositories.Department.UpdateDepartmentByDepartmentId;

/// <summary>
///     Repository interface for update
///     department by department id feature.
/// </summary>
public interface IUpdateDepartmentByDepartmentIdRepository
{
    IUpdateDepartmentByDepartmentIdCommand Command { get; }

    IUpdateDepartmentByDepartmentIdQuery Query { get; }
}
