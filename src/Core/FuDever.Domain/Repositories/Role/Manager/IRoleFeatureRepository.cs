using FuDever.Domain.Repositories.Role.CreateRole;
using FuDever.Domain.Repositories.Role.GetAllRoles;
using FuDever.Domain.Repositories.Role.GetAllRolesByRoleName;
using FuDever.Domain.Repositories.Role.GetAllTemporarilyRemovedRoles;
using FuDever.Domain.Repositories.Role.RemoveRolePermanentlyByRoleId;
using FuDever.Domain.Repositories.Role.RemoveRoleTemporarilyByRoleId;
using FuDever.Domain.Repositories.Role.RestoreRoleByRoleId;
using FuDever.Domain.Repositories.Role.UpdateRoleByRoleId;

namespace FuDever.Domain.Repositories.Role.Manager;

public interface IRoleFeatureRepository
{
    ICreateRoleRepository CreateRole { get; }

    IGetAllRolesRepository GetAllRoles { get; }

    IGetAllRolesByRoleNameRepository GetAllRolesByRoleName { get; }

    IGetAllTemporarilyRemovedRolesRepository GetAllTemporarilyRemovedRoles { get; }

    IRemoveRolePermanentlyByRoleIdRepository RemoveRolePermanentlyByRoleId { get; }

    IRemoveRoleTemporarilyByRoleIdRepository RemoveRoleTemporarilyByRoleId { get; }

    IRestoreRoleByRoleIdRepository RestoreRoleByRoleId { get; }

    IUpdateRoleByRoleIdRepository UpdateRoleByRoleId { get; }
}
