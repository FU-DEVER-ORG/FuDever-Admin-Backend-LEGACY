using FuDever.Domain.Repositories.Department.CreateDepartment;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Department.CreateDepartment.Others;

internal sealed class CreateDepartmentRepository : ICreateDepartmentRepository
{
    private readonly CreateDepartmentStateBag _stateBag;
    private ICreateDepartmentQuery _query;
    private ICreateDepartmentCommand _command;

    internal CreateDepartmentRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public ICreateDepartmentQuery Query
    {
        get { return _query ??= new CreateDepartmentQuery(stateBag: _stateBag); }
    }

    public ICreateDepartmentCommand Command
    {
        get { return _command ??= new CreateDepartmentCommand(stateBag: _stateBag); }
    }
}
