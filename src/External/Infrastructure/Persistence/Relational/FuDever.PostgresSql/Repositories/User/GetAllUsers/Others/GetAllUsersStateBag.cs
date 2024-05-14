using FuDever.PostgresSql.Data;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.User.GetAllUsers.Others;

internal sealed class GetAllUsersStateBag
{
    private DbSet<Domain.Entities.UserDetail> _userDetails;

    internal DbSet<Domain.Entities.UserDetail> UserDetails
    {
        get { return _userDetails ??= Context.Set<Domain.Entities.UserDetail>(); }
    }

    internal FuDeverContext Context { get; }

    internal GetAllUsersStateBag(FuDeverContext context)
    {
        Context = context;
    }
}
