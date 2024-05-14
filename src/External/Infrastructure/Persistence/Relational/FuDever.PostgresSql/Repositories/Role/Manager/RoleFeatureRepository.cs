using FuDever.Domain.Repositories.Role.CreateRole;
using FuDever.Domain.Repositories.Role.GetAllRoles;
using FuDever.Domain.Repositories.Role.GetAllRolesByRoleName;
using FuDever.Domain.Repositories.Role.GetAllTemporarilyRemovedRoles;
using FuDever.Domain.Repositories.Role.Manager;
using FuDever.Domain.Repositories.Role.RemoveRolePermanentlyByRoleId;
using FuDever.Domain.Repositories.Role.RemoveRoleTemporarilyByRoleId;
using FuDever.Domain.Repositories.Role.RestoreRoleByRoleId;
using FuDever.Domain.Repositories.Role.UpdateRoleByRoleId;
using FuDever.PostgresSql.Data;
using FuDever.PostgresSql.Repositories.Role.CreateRole.Others;
using FuDever.PostgresSql.Repositories.Role.GetAllRoles.Others;
using FuDever.PostgresSql.Repositories.Role.GetAllRolesByRoleName.Others;
using FuDever.PostgresSql.Repositories.Role.GetAllTemporarilyRemovedRoles.Others;
using FuDever.PostgresSql.Repositories.Role.RemoveRolePermanentlyByRoleId.Others;
using FuDever.PostgresSql.Repositories.Role.RemoveRoleTemporarilyByRoleId.Others;
using FuDever.PostgresSql.Repositories.Role.RestoreRoleByRoleId.Others;
using FuDever.PostgresSql.Repositories.Role.UpdateRoleByRoleId.Others;
using Microsoft.AspNetCore.Identity;

namespace FuDever.PostgresSql.Repositories.Role.Manager;

internal sealed class RoleFeatureRepository : IRoleFeatureRepository
{
    private ICreateRoleRepository _createRoleRepository;
    private IGetAllRolesRepository _getAllRolesRepository;
    private IGetAllRolesByRoleNameRepository _getAllRolesByRoleNameRepository;
    private IGetAllTemporarilyRemovedRolesRepository _getAllTemporarilyRemovedRolesRepository;
    private IRemoveRolePermanentlyByRoleIdRepository _removeRolePermanentlyByRoleIdRepository;
    private IRemoveRoleTemporarilyByRoleIdRepository _removeRoleTemporarilyByRoleIdRepository;
    private IRestoreRoleByRoleIdRepository _restoreRoleByRoleIdRepository;
    private IUpdateRoleByRoleIdRepository _updateRoleByRoleIdRepository;
    private readonly FuDeverContext _context;
    private readonly RoleManager<Domain.Entities.Role> _roleManager;

    internal RoleFeatureRepository(
        FuDeverContext context,
        RoleManager<Domain.Entities.Role> roleManager
    )
    {
        _context = context;
        _roleManager = roleManager;
    }

    public ICreateRoleRepository CreateRole
    {
        get
        {
            return _createRoleRepository ??= new CreateRoleRepository(
                context: _context,
                roleManager: _roleManager
            );
        }
    }

    public IGetAllRolesRepository GetAllRoles
    {
        get
        {
            return _getAllRolesRepository ??= new GetAllRolesRepository(
                context: _context,
                roleManager: _roleManager
            );
        }
    }

    public IGetAllRolesByRoleNameRepository GetAllRolesByRoleName
    {
        get
        {
            return _getAllRolesByRoleNameRepository ??= new GetAllRolesByRoleNameRepository(
                context: _context,
                roleManager: _roleManager
            );
        }
    }

    public IGetAllTemporarilyRemovedRolesRepository GetAllTemporarilyRemovedRoles
    {
        get
        {
            return _getAllTemporarilyRemovedRolesRepository ??=
                new GetAllTemporarilyRemovedRolesRepository(
                    context: _context,
                    roleManager: _roleManager
                );
        }
    }

    public IRemoveRolePermanentlyByRoleIdRepository RemoveRolePermanentlyByRoleId
    {
        get
        {
            return _removeRolePermanentlyByRoleIdRepository ??=
                new RemoveRolePermanentlyByRoleIdRepository(
                    context: _context,
                    roleManager: _roleManager
                );
        }
    }

    public IRemoveRoleTemporarilyByRoleIdRepository RemoveRoleTemporarilyByRoleId
    {
        get
        {
            return _removeRoleTemporarilyByRoleIdRepository ??=
                new RemoveRoleTemporarilyByRoleIdRepository(
                    context: _context,
                    roleManager: _roleManager
                );
        }
    }

    public IRestoreRoleByRoleIdRepository RestoreRoleByRoleId
    {
        get
        {
            return _restoreRoleByRoleIdRepository ??= new RestoreRoleByRoleIdRepository(
                context: _context,
                roleManager: _roleManager
            );
        }
    }

    public IUpdateRoleByRoleIdRepository UpdateRoleByRoleId
    {
        get
        {
            return _updateRoleByRoleIdRepository ??= new UpdateRoleByRoleIdRepository(
                context: _context,
                roleManager: _roleManager
            );
        }
    }
}
