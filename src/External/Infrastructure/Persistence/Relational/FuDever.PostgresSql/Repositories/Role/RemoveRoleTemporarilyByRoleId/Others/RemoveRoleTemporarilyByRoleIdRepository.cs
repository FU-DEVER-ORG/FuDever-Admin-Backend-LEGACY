using FuDever.Domain.Repositories.Role.RemoveRoleTemporarilyByRoleId;
using FuDever.PostgresSql.Data;
using Microsoft.AspNetCore.Identity;

namespace FuDever.PostgresSql.Repositories.Role.RemoveRoleTemporarilyByRoleId.Others;

internal sealed class RemoveRoleTemporarilyByRoleIdRepository
    : IRemoveRoleTemporarilyByRoleIdRepository
{
    private readonly RemoveRoleTemporarilyByRoleIdStateBag _stateBag;
    private IRemoveRoleTemporarilyByRoleIdCommand _commnad;
    private IRemoveRoleTemporarilyByRoleIdQuery _query;

    internal RemoveRoleTemporarilyByRoleIdRepository(
        FuDeverContext context,
        RoleManager<Domain.Entities.Role> roleManager
    )
    {
        _stateBag = new(context: context, roleManager: roleManager);
    }

    public IRemoveRoleTemporarilyByRoleIdCommand Command
    {
        get { return _commnad ??= new RemoveRoleTemporarilyByRoleIdCommand(stateBag: _stateBag); }
    }

    public IRemoveRoleTemporarilyByRoleIdQuery Query
    {
        get { return _query ??= new RemoveRoleTemporarilyByRoleIdQuery(stateBag: _stateBag); }
    }
}
