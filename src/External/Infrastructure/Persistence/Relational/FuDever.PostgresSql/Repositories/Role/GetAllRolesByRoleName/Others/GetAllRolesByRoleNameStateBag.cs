using FuDever.PostgresSql.Data;
using Microsoft.AspNetCore.Identity;

namespace FuDever.PostgresSql.Repositories.Role.GetAllRolesByRoleName.Others;

internal sealed class GetAllRolesByRoleNameStateBag
{
    internal RoleManager<Domain.Entities.Role> RoleManager { get; }

    internal FuDeverContext Context { get; }

    internal GetAllRolesByRoleNameStateBag(
        FuDeverContext context,
        RoleManager<Domain.Entities.Role> roleManager
    )
    {
        Context = context;
        RoleManager = roleManager;
    }
}
