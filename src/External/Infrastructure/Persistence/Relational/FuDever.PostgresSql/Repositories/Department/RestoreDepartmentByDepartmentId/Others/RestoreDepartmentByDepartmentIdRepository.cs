using FuDever.Domain.Repositories.Department.RestoreDepartmentByDepartmentId;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Department.RestoreDepartmentByDepartmentId.Others;

internal sealed class RestoreDepartmentByDepartmentIdRepository
    : IRestoreDepartmentByDepartmentIdRepository
{
    private readonly RestoreDepartmentByDepartmentIdStateBag _stateBag;
    private IRestoreDepartmentByDepartmentIdCommand _commnad;
    private IRestoreDepartmentByDepartmentIdQuery _query;

    internal RestoreDepartmentByDepartmentIdRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IRestoreDepartmentByDepartmentIdCommand Command
    {
        get { return _commnad ??= new RestoreDepartmentByDepartmentIdCommand(stateBag: _stateBag); }
    }

    public IRestoreDepartmentByDepartmentIdQuery Query
    {
        get { return _query ??= new RestoreDepartmentByDepartmentIdQuery(stateBag: _stateBag); }
    }
}
