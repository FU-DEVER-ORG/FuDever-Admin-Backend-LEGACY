namespace FuDever.Domain.Repositories.Role.GetAllRoles;

public interface IGetAllRolesRepository
{
    IGetAllRolesCommand Command { get; }

    IGetAllRolesQuery Query { get; }
}
