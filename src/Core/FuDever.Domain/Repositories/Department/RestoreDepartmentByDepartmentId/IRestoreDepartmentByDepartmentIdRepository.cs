namespace FuDever.Domain.Repositories.Department.RestoreDepartmentByDepartmentId;

/// <summary>
///     Repository interface for restore
///     department by department id feature.
/// </summary>
public interface IRestoreDepartmentByDepartmentIdRepository
{
    IRestoreDepartmentByDepartmentIdCommand Command { get; }

    IRestoreDepartmentByDepartmentIdQuery Query { get; }
}
