using FuDever.Domain.Repositories.Department.CreateDepartment;
using FuDever.Domain.Repositories.Department.GetAllDepartments;
using FuDever.Domain.Repositories.Department.GetAllDepartmentsByDepartmentName;
using FuDever.Domain.Repositories.Department.GetAllTemporarilyRemovedDepartments;
using FuDever.Domain.Repositories.Department.Manager;
using FuDever.Domain.Repositories.Department.RemoveDepartmentPermanentlyByDepartmentId;
using FuDever.Domain.Repositories.Department.RemoveDepartmentTemporarilyByDepartmentId;
using FuDever.Domain.Repositories.Department.RestoreDepartmentByDepartmentId;
using FuDever.Domain.Repositories.Department.UpdateDepartmentByDepartmentId;
using FuDever.PostgresSql.Data;
using FuDever.PostgresSql.Repositories.Department.CreateDepartment.Others;
using FuDever.PostgresSql.Repositories.Department.GetAllDepartments.Others;
using FuDever.PostgresSql.Repositories.Department.GetAllDepartmentsByDepartmentName.Others;
using FuDever.PostgresSql.Repositories.Department.GetAllTemporarilyRemovedDepartments.Others;
using FuDever.PostgresSql.Repositories.Department.RemoveDepartmentPermanentlyByDepartmentId.Others;
using FuDever.PostgresSql.Repositories.Department.RemoveDepartmentTemporarilyByDepartmentId.Others;
using FuDever.PostgresSql.Repositories.Department.RestoreDepartmentByDepartmentId.Others;
using FuDever.PostgresSql.Repositories.Department.UpdateDepartmentByDepartmentId.Others;

namespace FuDever.PostgresSql.Repositories.Department.Manager;

internal sealed class DepartmentFeatureRepository : IDepartmentFeatureRepository
{
    private readonly FuDeverContext _context;
    private ICreateDepartmentRepository _createDepartmentRepository;
    private IGetAllDepartmentsRepository _getAllDepartmentsRepository;
    private IGetAllDepartmentsByDepartmentNameRepository _getAllDepartmentsByDepartmentNameRepository;
    private IGetAllTemporarilyRemovedDepartmentsRepository _getAllTemporarilyRemovedDepartmentsRepository;
    private IRemoveDepartmentPermanentlyByDepartmentIdRepository _removeDepartmentPermanentlyByDepartmentIdRepository;
    private IRemoveDepartmentTemporarilyByDepartmentIdRepository _removeDepartmentTemporarilyByDepartmentIdRepository;
    private IRestoreDepartmentByDepartmentIdRepository _restoreDepartmentByDepartmentIdRepository;
    private IUpdateDepartmentByDepartmentIdRepository _updateDepartmentByDepartmentIdRepository;

    internal DepartmentFeatureRepository(FuDeverContext context)
    {
        _context = context;
    }

    public ICreateDepartmentRepository CreateDepartment
    {
        get
        {
            return _createDepartmentRepository ??= new CreateDepartmentRepository(
                context: _context
            );
        }
    }

    public IGetAllDepartmentsRepository GetAllDepartments
    {
        get
        {
            return _getAllDepartmentsRepository ??= new GetAllDepartmentsRepository(
                context: _context
            );
        }
    }

    public IGetAllDepartmentsByDepartmentNameRepository GetAllDepartmentsByDepartmentName
    {
        get
        {
            return _getAllDepartmentsByDepartmentNameRepository ??=
                new GetAllDepartmentsByDepartmentNameRepository(context: _context);
        }
    }

    public IGetAllTemporarilyRemovedDepartmentsRepository GetAllTemporarilyRemovedDepartments
    {
        get
        {
            return _getAllTemporarilyRemovedDepartmentsRepository ??=
                new GetAllTemporarilyRemovedDepartmentsRepository(context: _context);
        }
    }

    public IRemoveDepartmentPermanentlyByDepartmentIdRepository RemoveDepartmentPermanentlyByDepartmentId
    {
        get
        {
            return _removeDepartmentPermanentlyByDepartmentIdRepository ??=
                new RemoveDepartmentPermanentlyByDepartmentIdRepository(context: _context);
        }
    }

    public IRemoveDepartmentTemporarilyByDepartmentIdRepository RemoveDepartmentTemporarilyByDepartmentId
    {
        get
        {
            return _removeDepartmentTemporarilyByDepartmentIdRepository ??=
                new RemoveDepartmentTemporarilyByDepartmentIdRepository(context: _context);
        }
    }

    public IRestoreDepartmentByDepartmentIdRepository RestoreDepartmentByDepartmentId
    {
        get
        {
            return _restoreDepartmentByDepartmentIdRepository ??=
                new RestoreDepartmentByDepartmentIdRepository(context: _context);
        }
    }

    public IUpdateDepartmentByDepartmentIdRepository UpdateDepartmentByDepartmentId
    {
        get
        {
            return _updateDepartmentByDepartmentIdRepository ??=
                new UpdateDepartmentByDepartmentIdRepository(context: _context);
        }
    }
}
