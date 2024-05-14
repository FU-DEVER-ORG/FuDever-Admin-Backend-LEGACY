using FuDever.Domain.Repositories.Role.CreateRole;
using FuDever.PostgresSql.Data;
using Microsoft.AspNetCore.Identity;

namespace FuDever.PostgresSql.Repositories.Role.CreateRole.Others;

internal sealed class CreateRoleRepository : ICreateRoleRepository
{
    private readonly CreateRoleStateBag _stateBag;
    private ICreateRoleQuery _query;
    private ICreateRoleCommand _command;

    internal CreateRoleRepository(
        FuDeverContext context,
        RoleManager<Domain.Entities.Role> roleManager
    )
    {
        _stateBag = new(context: context, roleManager: roleManager);
    }

    public ICreateRoleQuery Query
    {
        get { return _query ??= new CreateRoleQuery(stateBag: _stateBag); }
    }

    public ICreateRoleCommand Command
    {
        get { return _command ??= new CreateRoleCommand(stateBag: _stateBag); }
    }
}
