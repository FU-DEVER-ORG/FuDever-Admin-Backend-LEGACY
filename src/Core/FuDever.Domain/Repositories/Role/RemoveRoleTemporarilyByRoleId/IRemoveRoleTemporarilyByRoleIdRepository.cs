namespace FuDever.Domain.Repositories.Role.RemoveRoleTemporarilyByRoleId;

public interface IRemoveRoleTemporarilyByRoleIdRepository
{
    IRemoveRoleTemporarilyByRoleIdCommand Command { get; }

    IRemoveRoleTemporarilyByRoleIdQuery Query { get; }
}
