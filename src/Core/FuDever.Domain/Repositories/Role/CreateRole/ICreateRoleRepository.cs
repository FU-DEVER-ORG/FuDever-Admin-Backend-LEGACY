namespace FuDever.Domain.Repositories.Role.CreateRole;

public interface ICreateRoleRepository
{
    ICreateRoleCommand Command { get; }

    ICreateRoleQuery Query { get; }
}
