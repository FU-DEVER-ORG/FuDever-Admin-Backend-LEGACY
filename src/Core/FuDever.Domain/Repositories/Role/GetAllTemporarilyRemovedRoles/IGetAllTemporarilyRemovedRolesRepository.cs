namespace FuDever.Domain.Repositories.Role.GetAllTemporarilyRemovedRoles;

public interface IGetAllTemporarilyRemovedRolesRepository
{
    IGetAllTemporarilyRemovedRolesCommand Command { get; }

    IGetAllTemporarilyRemovedRolesQuery Query { get; }
}
