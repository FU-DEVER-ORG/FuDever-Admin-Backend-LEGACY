namespace FuDever.Domain.Repositories.Role.RemoveRolePermanentlyByRoleId;

public interface IRemoveRolePermanentlyByRoleIdRepository
{
    IRemoveRolePermanentlyByRoleIdCommand Command { get; }

    IRemoveRolePermanentlyByRoleIdQuery Query { get; }
}
