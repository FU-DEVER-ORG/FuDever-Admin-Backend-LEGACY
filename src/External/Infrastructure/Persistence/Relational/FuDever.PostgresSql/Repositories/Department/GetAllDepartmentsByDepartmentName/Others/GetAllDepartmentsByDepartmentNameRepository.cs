using FuDever.Domain.Repositories.Department.GetAllDepartmentsByDepartmentName;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Department.GetAllDepartmentsByDepartmentName.Others;

internal sealed class GetAllDepartmentsByDepartmentNameRepository
    : IGetAllDepartmentsByDepartmentNameRepository
{
    private readonly GetAllDepartmentsByDepartmentNameStateBag _stateBag;
    private IGetAllDepartmentsByDepartmentNameCommand _commnad;
    private IGetAllDepartmentsByDepartmentNameQuery _query;

    internal GetAllDepartmentsByDepartmentNameRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IGetAllDepartmentsByDepartmentNameCommand Command
    {
        get { return _commnad ??= new GetAllDepartmentsByDepartmentNameCommand(); }
    }

    public IGetAllDepartmentsByDepartmentNameQuery Query
    {
        get { return _query ??= new GetAllDepartmentsByDepartmentNameQuery(stateBag: _stateBag); }
    }
}
