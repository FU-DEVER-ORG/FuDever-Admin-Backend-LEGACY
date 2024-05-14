namespace FuDever.Domain.Repositories.Department.GetAllTemporarilyRemovedDepartments;

/// <summary>
///     Repository interface for get all
///     temporarily removed departments feature.
/// </summary>
public interface IGetAllTemporarilyRemovedDepartmentsRepository
{
    IGetAllTemporarilyRemovedDepartmentsCommand Command { get; }

    IGetAllTemporarilyRemovedDepartmentsQuery Query { get; }
}
