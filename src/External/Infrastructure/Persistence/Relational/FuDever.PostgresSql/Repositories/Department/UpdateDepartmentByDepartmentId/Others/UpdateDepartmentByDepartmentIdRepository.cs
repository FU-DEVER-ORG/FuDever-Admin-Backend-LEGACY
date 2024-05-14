using FuDever.Domain.Repositories.Department.UpdateDepartmentByDepartmentId;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Department.UpdateDepartmentByDepartmentId.Others;

internal sealed class UpdateDepartmentByDepartmentIdRepository
    : IUpdateDepartmentByDepartmentIdRepository
{
    private readonly UpdateDepartmentByDepartmentIdStateBag _stateBag;
    private IUpdateDepartmentByDepartmentIdCommand _commnad;
    private IUpdateDepartmentByDepartmentIdQuery _query;

    internal UpdateDepartmentByDepartmentIdRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IUpdateDepartmentByDepartmentIdCommand Command
    {
        get { return _commnad ??= new UpdateDepartmentByDepartmentIdCommand(stateBag: _stateBag); }
    }

    public IUpdateDepartmentByDepartmentIdQuery Query
    {
        get { return _query ??= new UpdateDepartmentByDepartmentIdQuery(stateBag: _stateBag); }
    }
}
