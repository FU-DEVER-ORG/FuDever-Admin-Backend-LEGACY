using FuDever.PostgresSql.Data;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Hobby.GetAllHobbiesByHobbyName.Others;

internal sealed class GetAllHobbiesByHobbyNameStateBag
{
    private DbSet<Domain.Entities.Hobby> _hobbies;

    internal DbSet<Domain.Entities.Hobby> Hobbies
    {
        get { return _hobbies ??= Context.Set<Domain.Entities.Hobby>(); }
    }

    internal FuDeverContext Context { get; }

    internal GetAllHobbiesByHobbyNameStateBag(FuDeverContext context)
    {
        Context = context;
    }
}
