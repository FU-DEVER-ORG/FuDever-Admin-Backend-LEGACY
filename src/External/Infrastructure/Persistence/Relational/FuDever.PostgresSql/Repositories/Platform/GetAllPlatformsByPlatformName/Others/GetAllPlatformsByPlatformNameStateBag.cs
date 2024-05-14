using FuDever.PostgresSql.Data;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Platform.GetAllPlatformsByPlatformName.Others;

internal sealed class GetAllPlatformsByPlatformNameStateBag
{
    private DbSet<Domain.Entities.Platform> _platforms;

    internal DbSet<Domain.Entities.Platform> Platforms
    {
        get { return _platforms ??= Context.Set<Domain.Entities.Platform>(); }
    }

    internal FuDeverContext Context { get; }

    internal GetAllPlatformsByPlatformNameStateBag(FuDeverContext context)
    {
        Context = context;
    }
}
