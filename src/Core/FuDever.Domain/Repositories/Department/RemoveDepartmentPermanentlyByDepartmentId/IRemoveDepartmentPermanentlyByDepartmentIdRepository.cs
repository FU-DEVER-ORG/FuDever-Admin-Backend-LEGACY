namespace FuDever.Domain.Repositories.Department.RemoveDepartmentPermanentlyByDepartmentId;

/// <summary>
///     Repository interface for remove department
///     permanently by department id feature.
/// </summary>
public interface IRemoveDepartmentPermanentlyByDepartmentIdRepository
{
    IRemoveDepartmentPermanentlyByDepartmentIdCommand Command { get; }

    IRemoveDepartmentPermanentlyByDepartmentIdQuery Query { get; }
}
