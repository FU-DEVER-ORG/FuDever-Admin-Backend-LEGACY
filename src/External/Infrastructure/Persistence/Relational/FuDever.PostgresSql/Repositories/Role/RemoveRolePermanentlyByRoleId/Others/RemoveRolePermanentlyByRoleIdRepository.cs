using FuDever.Domain.Repositories.Role.RemoveRolePermanentlyByRoleId;
using FuDever.PostgresSql.Data;
using Microsoft.AspNetCore.Identity;

namespace FuDever.PostgresSql.Repositories.Role.RemoveRolePermanentlyByRoleId.Others;

internal sealed class RemoveRolePermanentlyByRoleIdRepository
    : IRemoveRolePermanentlyByRoleIdRepository
{
    private readonly RemoveRolePermanentlyByRoleIdStateBag _stateBag;
    private IRemoveRolePermanentlyByRoleIdCommand _commnad;
    private IRemoveRolePermanentlyByRoleIdQuery _query;

    internal RemoveRolePermanentlyByRoleIdRepository(
        FuDeverContext context,
        RoleManager<Domain.Entities.Role> roleManager
    )
    {
        _stateBag = new(context: context, roleManager: roleManager);
    }

    public IRemoveRolePermanentlyByRoleIdCommand Command
    {
        get { return _commnad ??= new RemoveRolePermanentlyByRoleIdCommand(stateBag: _stateBag); }
    }

    public IRemoveRolePermanentlyByRoleIdQuery Query
    {
        get { return _query ??= new RemoveRolePermanentlyByRoleIdQuery(stateBag: _stateBag); }
    }
}
