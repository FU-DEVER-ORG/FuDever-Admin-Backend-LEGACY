using FuDever.PostgresSql.Data;
using Microsoft.AspNetCore.Identity;

namespace FuDever.PostgresSql.Repositories.Role.GetAllRoles.Others;

internal sealed class GetAllRolesStateBag
{
    internal RoleManager<Domain.Entities.Role> RoleManager { get; }

    internal FuDeverContext Context { get; }

    internal GetAllRolesStateBag(
        FuDeverContext context,
        RoleManager<Domain.Entities.Role> roleManager
    )
    {
        Context = context;
        RoleManager = roleManager;
    }
}
