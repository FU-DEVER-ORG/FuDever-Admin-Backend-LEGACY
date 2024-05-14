using FuDever.PostgresSql.Data;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Position.RestorePositionByPositionId.Others;

internal sealed class RestorePositionByPositionIdStateBag
{
    private DbSet<Domain.Entities.Position> _positions;
    private DbSet<Domain.Entities.RefreshToken> _refreshTokens;
    private DbSet<Domain.Entities.UserDetail> _userDetails;

    internal DbSet<Domain.Entities.Position> Positions
    {
        get { return _positions ??= Context.Set<Domain.Entities.Position>(); }
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

    internal RestorePositionByPositionIdStateBag(FuDeverContext context)
    {
        Context = context;
    }
}
