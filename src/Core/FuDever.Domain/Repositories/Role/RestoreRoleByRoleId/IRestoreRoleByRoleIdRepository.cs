namespace FuDever.Domain.Repositories.Role.RestoreRoleByRoleId;

public interface IRestoreRoleByRoleIdRepository
{
    IRestoreRoleByRoleIdCommand Command { get; }

    IRestoreRoleByRoleIdQuery Query { get; }
}
