namespace FuDever.Domain.Repositories.Role.GetAllRolesByRoleName;

public interface IGetAllRolesByRoleNameRepository
{
    IGetAllRolesByRoleNameCommand Command { get; }

    IGetAllRolesByRoleNameQuery Query { get; }
}
