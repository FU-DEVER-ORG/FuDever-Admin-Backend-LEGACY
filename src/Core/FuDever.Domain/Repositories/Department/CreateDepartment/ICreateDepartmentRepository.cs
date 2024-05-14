namespace FuDever.Domain.Repositories.Department.CreateDepartment;

/// <summary>
///     Repository interface for creating a department feature.
/// </summary>
public interface ICreateDepartmentRepository
{
    ICreateDepartmentQuery Query { get; }

    ICreateDepartmentCommand Command { get; }
}
