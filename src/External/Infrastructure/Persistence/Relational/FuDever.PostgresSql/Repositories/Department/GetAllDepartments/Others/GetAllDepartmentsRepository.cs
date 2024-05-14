using FuDever.Domain.Repositories.Department.GetAllDepartments;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Department.GetAllDepartments.Others;

internal sealed class GetAllDepartmentsRepository : IGetAllDepartmentsRepository
{
    private readonly GetAllDepartmentsStateBag _stateBag;
    private IGetAllDepartmentsCommand _commnad;
    private IGetAllDepartmentsQuery _query;

    internal GetAllDepartmentsRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IGetAllDepartmentsCommand Command
    {
        get { return _commnad ??= new GetAllDepartmentsCommand(); }
    }

    public IGetAllDepartmentsQuery Query
    {
        get { return _query ??= new GetAllDepartmentsQuery(stateBag: _stateBag); }
    }
}
