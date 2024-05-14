using FuDever.PostgresSql.Data;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Admin.RejectNewUser.Others;

internal sealed class RejectNewUserStateBag
{
    private DbSet<Domain.Entities.UserDetail> _userDetails;
    private DbSet<Domain.Entities.RefreshToken> _refreshTokens;
    private DbSet<Domain.Entities.UserJoiningStatus> _userJoiningStatuses;

    internal DbSet<Domain.Entities.UserJoiningStatus> UserJoiningStatuses
    {
        get { return _userJoiningStatuses ??= Context.Set<Domain.Entities.UserJoiningStatus>(); }
    }

    internal DbSet<Domain.Entities.RefreshToken> RefreshTokens
    {
        get { return _refreshTokens ??= Context.Set<Domain.Entities.RefreshToken>(); }
    }

    internal DbSet<Domain.Entities.UserDetail> UserDetails
    {
        get { return _userDetails ??= Context.Set<Domain.Entities.UserDetail>(); }
    }

    internal FuDeverContext Context { get; }

    internal RejectNewUserStateBag(FuDeverContext context)
    {
        Context = context;
    }
}
