namespace FuDever.Domain.Repositories.Department.GetAllDepartments;

/// <summary>
///     Repository interface for get all departments feature.
/// </summary>
public interface IGetAllDepartmentsRepository
{
    IGetAllDepartmentsCommand Command { get; }

    IGetAllDepartmentsQuery Query { get; }
}
