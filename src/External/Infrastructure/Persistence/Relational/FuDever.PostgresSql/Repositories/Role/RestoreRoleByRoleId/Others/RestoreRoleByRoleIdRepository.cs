using FuDever.Domain.Repositories.Role.RestoreRoleByRoleId;
using FuDever.PostgresSql.Data;
using Microsoft.AspNetCore.Identity;

namespace FuDever.PostgresSql.Repositories.Role.RestoreRoleByRoleId.Others;

internal sealed class RestoreRoleByRoleIdRepository : IRestoreRoleByRoleIdRepository
{
    private readonly RestoreRoleByRoleIdStateBag _stateBag;
    private IRestoreRoleByRoleIdCommand _commnad;
    private IRestoreRoleByRoleIdQuery _query;

    internal RestoreRoleByRoleIdRepository(
        FuDeverContext context,
        RoleManager<Domain.Entities.Role> roleManager
    )
    {
        _stateBag = new(context: context, roleManager: roleManager);
    }

    public IRestoreRoleByRoleIdCommand Command
    {
        get { return _commnad ??= new RestoreRoleByRoleIdCommand(stateBag: _stateBag); }
    }

    public IRestoreRoleByRoleIdQuery Query
    {
        get { return _query ??= new RestoreRoleByRoleIdQuery(stateBag: _stateBag); }
    }
}
