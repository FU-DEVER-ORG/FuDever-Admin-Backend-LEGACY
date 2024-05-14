using FuDever.PostgresSql.Data;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Major.GetAllMajors.Others;

internal sealed class GetAllMajorsStateBag
{
    private DbSet<Domain.Entities.Major> _majors;

    internal DbSet<Domain.Entities.Major> Majors
    {
        get { return _majors ??= Context.Set<Domain.Entities.Major>(); }
    }

    internal FuDeverContext Context { get; }

    internal GetAllMajorsStateBag(FuDeverContext context)
    {
        Context = context;
    }
}
