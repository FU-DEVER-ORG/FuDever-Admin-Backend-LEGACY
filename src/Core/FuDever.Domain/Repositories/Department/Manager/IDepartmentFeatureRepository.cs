using FuDever.Domain.Repositories.Department.CreateDepartment;
using FuDever.Domain.Repositories.Department.GetAllDepartments;
using FuDever.Domain.Repositories.Department.GetAllDepartmentsByDepartmentName;
using FuDever.Domain.Repositories.Department.GetAllTemporarilyRemovedDepartments;
using FuDever.Domain.Repositories.Department.RemoveDepartmentPermanentlyByDepartmentId;
using FuDever.Domain.Repositories.Department.RemoveDepartmentTemporarilyByDepartmentId;
using FuDever.Domain.Repositories.Department.RestoreDepartmentByDepartmentId;
using FuDever.Domain.Repositories.Department.UpdateDepartmentByDepartmentId;

namespace FuDever.Domain.Repositories.Department.Manager;

/// <summary>
///     Interface for department repository manager.
/// </summary>
public interface IDepartmentFeatureRepository
{
    /// <summary>
    ///     Gets create department repository.
    /// </summary>
    ICreateDepartmentRepository CreateDepartment { get; }

    /// <summary>
    ///     Gets get all departments repository.
    /// </summary>
    IGetAllDepartmentsRepository GetAllDepartments { get; }

    /// <summary>
    ///     Gets get all departments by department name repository.
    /// </summary>
    IGetAllDepartmentsByDepartmentNameRepository GetAllDepartmentsByDepartmentName { get; }

    /// <summary>
    ///     Gets get all temporarily removed departments repository.
    /// </summary>
    IGetAllTemporarilyRemovedDepartmentsRepository GetAllTemporarilyRemovedDepartments { get; }

    /// <summary>
    ///     Gets remove department permanently by department id repository.
    /// </summary>
    IRemoveDepartmentPermanentlyByDepartmentIdRepository RemoveDepartmentPermanentlyByDepartmentId { get; }

    /// <summary>
    ///     Gets remove department temporarily by department id repository.
    /// </summary>
    IRemoveDepartmentTemporarilyByDepartmentIdRepository RemoveDepartmentTemporarilyByDepartmentId { get; }

    /// <summary>
    ///     Gets restore department by department id repository.
    /// </summary>
    IRestoreDepartmentByDepartmentIdRepository RestoreDepartmentByDepartmentId { get; }

    /// <summary>
    ///     Gets update department by department id repository.
    /// </summary>
    IUpdateDepartmentByDepartmentIdRepository UpdateDepartmentByDepartmentId { get; }
}
