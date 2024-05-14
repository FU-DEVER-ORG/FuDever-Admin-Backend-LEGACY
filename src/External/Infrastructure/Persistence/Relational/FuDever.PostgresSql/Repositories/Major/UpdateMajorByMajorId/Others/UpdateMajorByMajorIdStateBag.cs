﻿using FuDever.PostgresSql.Data;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Major.UpdateMajorByMajorId.Others;

internal sealed class UpdateMajorByMajorIdStateBag
{
    private DbSet<Domain.Entities.Major> _majors;
    private DbSet<Domain.Entities.UserDetail> _userDetails;
    private DbSet<Domain.Entities.RefreshToken> _refreshTokens;

    internal DbSet<Domain.Entities.Major> Majors
    {
        get { return _majors ??= Context.Set<Domain.Entities.Major>(); }
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

    internal UpdateMajorByMajorIdStateBag(FuDeverContext context)
    {
        Context = context;
    }
}
