using FuDever.Domain.Repositories.Role.GetAllRolesByRoleName;
using FuDever.PostgresSql.Data;
using Microsoft.AspNetCore.Identity;

namespace FuDever.PostgresSql.Repositories.Role.GetAllRolesByRoleName.Others;

internal sealed class GetAllRolesByRoleNameRepository : IGetAllRolesByRoleNameRepository
{
    private readonly GetAllRolesByRoleNameStateBag _stateBag;
    private IGetAllRolesByRoleNameQuery _query;
    private IGetAllRolesByRoleNameCommand _command;

    internal GetAllRolesByRoleNameRepository(
        FuDeverContext context,
        RoleManager<Domain.Entities.Role> roleManager
    )
    {
        _stateBag = new(context: context, roleManager: roleManager);
    }

    public IGetAllRolesByRoleNameQuery Query
    {
        get { return _query ??= new GetAllRolesByRoleNameQuery(stateBag: _stateBag); }
    }

    public IGetAllRolesByRoleNameCommand Command
    {
        get { return _command ??= new GetAllRolesByRoleNameCommand(); }
    }
}
