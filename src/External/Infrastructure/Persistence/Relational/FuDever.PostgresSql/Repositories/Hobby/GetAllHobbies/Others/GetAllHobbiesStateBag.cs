using FuDever.PostgresSql.Data;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Hobby.GetAllHobbies.Others;

internal sealed class GetAllHobbiesStateBag
{
    private DbSet<Domain.Entities.Hobby> _hobbies;

    internal DbSet<Domain.Entities.Hobby> Hobbies
    {
        get { return _hobbies ??= Context.Set<Domain.Entities.Hobby>(); }
    }

    internal FuDeverContext Context { get; }

    internal GetAllHobbiesStateBag(FuDeverContext context)
    {
        Context = context;
    }
}
