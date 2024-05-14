using FuDever.PostgresSql.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Role.RemoveRoleTemporarilyByRoleId.Others;

internal sealed class RemoveRoleTemporarilyByRoleIdStateBag
{
    private DbSet<Domain.Entities.RefreshToken> _refreshTokens;
    private DbSet<Domain.Entities.UserDetail> _userDetails;

    internal RoleManager<Domain.Entities.Role> RoleManager { get; }

    internal DbSet<Domain.Entities.RefreshToken> RefreshTokens
    {
        get { return _refreshTokens ??= Context.Set<Domain.Entities.RefreshToken>(); }
    }

    internal DbSet<Domain.Entities.UserDetail> UserDetails
    {
        get { return _userDetails ??= Context.Set<Domain.Entities.UserDetail>(); }
    }

    internal FuDeverContext Context { get; }

    internal RemoveRoleTemporarilyByRoleIdStateBag(
        FuDeverContext context,
        RoleManager<Domain.Entities.Role> roleManager
    )
    {
        Context = context;
        RoleManager = roleManager;
    }
}
