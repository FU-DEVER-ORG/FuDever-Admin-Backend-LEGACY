using FuDever.Domain.Repositories.Department.GetAllTemporarilyRemovedDepartments;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Department.GetAllTemporarilyRemovedDepartments.Others;

internal sealed class GetAllTemporarilyRemovedDepartmentsRepository
    : IGetAllTemporarilyRemovedDepartmentsRepository
{
    private readonly GetAllTemporarilyRemovedDepartmentsStateBag _stateBag;
    private IGetAllTemporarilyRemovedDepartmentsCommand _commnad;
    private IGetAllTemporarilyRemovedDepartmentsQuery _query;

    internal GetAllTemporarilyRemovedDepartmentsRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IGetAllTemporarilyRemovedDepartmentsCommand Command
    {
        get { return _commnad ??= new GetAllTemporarilyRemovedDepartmentsCommand(); }
    }

    public IGetAllTemporarilyRemovedDepartmentsQuery Query
    {
        get { return _query ??= new GetAllTemporarilyRemovedDepartmentsQuery(stateBag: _stateBag); }
    }
}
