using FuDever.Domain.Repositories.Role.GetAllRoles;
using FuDever.PostgresSql.Data;
using Microsoft.AspNetCore.Identity;

namespace FuDever.PostgresSql.Repositories.Role.GetAllRoles.Others;

internal sealed class GetAllRolesRepository : IGetAllRolesRepository
{
    private readonly GetAllRolesStateBag _stateBag;
    private IGetAllRolesQuery _query;
    private IGetAllRolesCommand _command;

    internal GetAllRolesRepository(
        FuDeverContext context,
        RoleManager<Domain.Entities.Role> roleManager
    )
    {
        _stateBag = new(context: context, roleManager: roleManager);
    }

    public IGetAllRolesQuery Query
    {
        get { return _query ??= new GetAllRolesQuery(stateBag: _stateBag); }
    }

    public IGetAllRolesCommand Command
    {
        get { return _command ??= new GetAllRolesCommand(); }
    }
}
