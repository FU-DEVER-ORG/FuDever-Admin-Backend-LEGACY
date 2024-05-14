namespace FuDever.Domain.Repositories.Role.UpdateRoleByRoleId;

public interface IUpdateRoleByRoleIdRepository
{
    IUpdateRoleByRoleIdCommand Command { get; }

    IUpdateRoleByRoleIdQuery Query { get; }
}
