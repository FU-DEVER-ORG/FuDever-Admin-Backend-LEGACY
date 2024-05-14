using FuDever.PostgresSql.Data;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Auth.ResendUserRegistrationConfirmedEmail.Others;

internal sealed class ResendUserRegistrationConfirmedEmailStateBag
{
    private DbSet<Domain.Entities.UserDetail> _userDetails;

    internal DbSet<Domain.Entities.UserDetail> UserDetails
    {
        get { return _userDetails ??= Context.Set<Domain.Entities.UserDetail>(); }
    }

    internal FuDeverContext Context { get; }

    internal ResendUserRegistrationConfirmedEmailStateBag(FuDeverContext context)
    {
        Context = context;
    }
}
