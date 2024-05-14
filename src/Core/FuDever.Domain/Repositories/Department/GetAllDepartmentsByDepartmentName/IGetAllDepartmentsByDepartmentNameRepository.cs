namespace FuDever.Domain.Repositories.Department.GetAllDepartmentsByDepartmentName;

/// <summary>
///     Repository interface for get all
///     departments by department name feature.
/// </summary>
public interface IGetAllDepartmentsByDepartmentNameRepository
{
    IGetAllDepartmentsByDepartmentNameCommand Command { get; }

    IGetAllDepartmentsByDepartmentNameQuery Query { get; }
}
