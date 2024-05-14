using FuDever.PostgresSql.Data;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Major.GetAllMajorsByMajorName.Others;

internal sealed class GetAllMajorsByMajorNameStateBag
{
    private DbSet<Domain.Entities.Major> _majors;

    internal DbSet<Domain.Entities.Major> Majors
    {
        get { return _majors ??= Context.Set<Domain.Entities.Major>(); }
    }

    internal FuDeverContext Context { get; }

    internal GetAllMajorsByMajorNameStateBag(FuDeverContext context)
    {
        Context = context;
    }
}
