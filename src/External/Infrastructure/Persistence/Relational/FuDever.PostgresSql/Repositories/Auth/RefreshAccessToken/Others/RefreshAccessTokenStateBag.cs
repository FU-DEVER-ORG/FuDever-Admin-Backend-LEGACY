﻿using FuDever.PostgresSql.Data;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Auth.RefreshAccessToken.Others;

internal sealed class RefreshAccessTokenStateBag
{
    private DbSet<Domain.Entities.RefreshToken> _refreshTokens;
    private DbSet<Domain.Entities.UserDetail> _userDetails;

    internal DbSet<Domain.Entities.RefreshToken> RefreshTokens
    {
        get { return _refreshTokens ??= Context.Set<Domain.Entities.RefreshToken>(); }
    }

    internal DbSet<Domain.Entities.UserDetail> UserDetails
    {
        get { return _userDetails ??= Context.Set<Domain.Entities.UserDetail>(); }
    }

    internal FuDeverContext Context { get; }

    internal RefreshAccessTokenStateBag(FuDeverContext context)
    {
        Context = context;
    }
}
