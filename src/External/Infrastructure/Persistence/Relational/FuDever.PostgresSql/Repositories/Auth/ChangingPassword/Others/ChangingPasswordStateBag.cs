using FuDever.PostgresSql.Data;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Auth.ChangingPassword.Others;

internal sealed class ChangingPasswordStateBag
{
    private DbSet<Domain.Entities.UserToken> _userTokens;
    private DbSet<Domain.Entities.UserDetail> _userDetails;

    internal DbSet<Domain.Entities.UserToken> UserTokens
    {
        get { return _userTokens ??= Context.Set<Domain.Entities.UserToken>(); }
    }

    internal DbSet<Domain.Entities.UserDetail> UserDetails
    {
        get { return _userDetails ??= Context.Set<Domain.Entities.UserDetail>(); }
    }

    internal FuDeverContext Context { get; }

    internal ChangingPasswordStateBag(FuDeverContext context)
    {
        Context = context;
    }
}
