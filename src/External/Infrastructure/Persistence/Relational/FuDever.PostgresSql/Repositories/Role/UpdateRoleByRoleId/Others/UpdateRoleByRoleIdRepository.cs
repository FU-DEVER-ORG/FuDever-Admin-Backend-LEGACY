using FuDever.Domain.Repositories.Role.UpdateRoleByRoleId;
using FuDever.PostgresSql.Data;
using Microsoft.AspNetCore.Identity;

namespace FuDever.PostgresSql.Repositories.Role.UpdateRoleByRoleId.Others;

internal sealed class UpdateRoleByRoleIdRepository : IUpdateRoleByRoleIdRepository
{
    private readonly UpdateRoleByRoleIdStateBag _stateBag;
    private IUpdateRoleByRoleIdCommand _commnad;
    private IUpdateRoleByRoleIdQuery _query;

    internal UpdateRoleByRoleIdRepository(
        FuDeverContext context,
        RoleManager<Domain.Entities.Role> roleManager
    )
    {
        _stateBag = new(context: context, roleManager: roleManager);
    }

    public IUpdateRoleByRoleIdCommand Command
    {
        get { return _commnad ??= new UpdateRoleByRoleIdCommand(stateBag: _stateBag); }
    }

    public IUpdateRoleByRoleIdQuery Query
    {
        get { return _query ??= new UpdateRoleByRoleIdQuery(stateBag: _stateBag); }
    }
}
