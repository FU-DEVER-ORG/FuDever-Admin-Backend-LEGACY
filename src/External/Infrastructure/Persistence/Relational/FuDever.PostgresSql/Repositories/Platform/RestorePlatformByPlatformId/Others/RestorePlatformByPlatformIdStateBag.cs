﻿using FuDever.PostgresSql.Data;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Platform.RestorePlatformByPlatformId.Others;

internal sealed class RestorePlatformByPlatformIdStateBag
{
    private DbSet<Domain.Entities.Platform> _platforms;
    private DbSet<Domain.Entities.RefreshToken> _refreshTokens;
    private DbSet<Domain.Entities.UserDetail> _userDetails;

    internal DbSet<Domain.Entities.Platform> Platforms
    {
        get { return _platforms ??= Context.Set<Domain.Entities.Platform>(); }
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

    internal RestorePlatformByPlatformIdStateBag(FuDeverContext context)
    {
        Context = context;
    }
}
