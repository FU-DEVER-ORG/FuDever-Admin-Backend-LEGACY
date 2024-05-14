using FuDever.PostgresSql.Data;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Platform.GetAllPlatforms.Others;

internal sealed class GetAllPlatformsStateBag
{
    private DbSet<Domain.Entities.Platform> _platforms;

    internal DbSet<Domain.Entities.Platform> Platforms
    {
        get { return _platforms ??= Context.Set<Domain.Entities.Platform>(); }
    }

    internal FuDeverContext Context { get; }

    internal GetAllPlatformsStateBag(FuDeverContext context)
    {
        Context = context;
    }
}
