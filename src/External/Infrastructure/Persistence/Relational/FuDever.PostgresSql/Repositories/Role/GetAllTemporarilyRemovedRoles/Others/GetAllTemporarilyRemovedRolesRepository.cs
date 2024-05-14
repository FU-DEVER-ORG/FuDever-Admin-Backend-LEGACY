using FuDever.Domain.Repositories.Role.GetAllTemporarilyRemovedRoles;
using FuDever.PostgresSql.Data;
using Microsoft.AspNetCore.Identity;

namespace FuDever.PostgresSql.Repositories.Role.GetAllTemporarilyRemovedRoles.Others;

internal sealed class GetAllTemporarilyRemovedRolesRepository
    : IGetAllTemporarilyRemovedRolesRepository
{
    private readonly GetAllTemporarilyRemovedRolesStateBag _stateBag;
    private IGetAllTemporarilyRemovedRolesQuery _query;
    private IGetAllTemporarilyRemovedRolesCommand _command;

    internal GetAllTemporarilyRemovedRolesRepository(
        FuDeverContext context,
        RoleManager<Domain.Entities.Role> roleManager
    )
    {
        _stateBag = new(context: context, roleManager: roleManager);
    }

    public IGetAllTemporarilyRemovedRolesQuery Query
    {
        get { return _query ??= new GetAllTemporarilyRemovedRolesQuery(stateBag: _stateBag); }
    }

    public IGetAllTemporarilyRemovedRolesCommand Command
    {
        get { return _command ??= new GetAllTemporarilyRemovedRolesCommand(); }
    }
}
