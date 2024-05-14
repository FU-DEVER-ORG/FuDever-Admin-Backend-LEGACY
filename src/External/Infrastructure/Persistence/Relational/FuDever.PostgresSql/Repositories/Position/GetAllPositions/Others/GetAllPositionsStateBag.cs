using FuDever.PostgresSql.Data;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Position.GetAllPositions.Others;

internal sealed class GetAllPositionsStateBag
{
    private DbSet<Domain.Entities.Position> _positions;

    internal DbSet<Domain.Entities.Position> Positions
    {
        get { return _positions ??= Context.Set<Domain.Entities.Position>(); }
    }

    internal FuDeverContext Context { get; }

    internal GetAllPositionsStateBag(FuDeverContext context)
    {
        Context = context;
    }
}
