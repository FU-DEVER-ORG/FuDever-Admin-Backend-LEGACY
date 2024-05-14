using FuDever.PostgresSql.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Auth.RegisterAsUser.Others;

internal sealed class RegisterAsUserStateBag
{
    private DbSet<Domain.Entities.UserJoiningStatus> _userJoiningStatuses;

    internal DbSet<Domain.Entities.UserJoiningStatus> UserJoiningStatuses
    {
        get { return _userJoiningStatuses ??= Context.Set<Domain.Entities.UserJoiningStatus>(); }
    }

    internal UserManager<Domain.Entities.User> UserManager { get; }

    internal FuDeverContext Context { get; }

    internal RegisterAsUserStateBag(
        FuDeverContext context,
        UserManager<Domain.Entities.User> userManager
    )
    {
        Context = context;
        UserManager = userManager;
    }
}
