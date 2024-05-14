using FuDever.PostgresSql.Data;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Hobby.CreateHobby.Others;

internal sealed class CreateHobbyStateBag
{
    private DbSet<Domain.Entities.Hobby> _hobbies;
    private DbSet<Domain.Entities.RefreshToken> _refreshTokens;
    private DbSet<Domain.Entities.UserDetail> _userDetails;

    internal DbSet<Domain.Entities.Hobby> Hobbies
    {
        get { return _hobbies ??= Context.Set<Domain.Entities.Hobby>(); }
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

    internal CreateHobbyStateBag(FuDeverContext context)
    {
        Context = context;
    }
}
