namespace FuDever.Domain.Repositories.Department.RemoveDepartmentTemporarilyByDepartmentId;

/// <summary>
///     Repository interface for remove department
///     temporarily by department id feature.
/// </summary>
public interface IRemoveDepartmentTemporarilyByDepartmentIdRepository
{
    IRemoveDepartmentTemporarilyByDepartmentIdCommand Command { get; }

    IRemoveDepartmentTemporarilyByDepartmentIdQuery Query { get; }
}
