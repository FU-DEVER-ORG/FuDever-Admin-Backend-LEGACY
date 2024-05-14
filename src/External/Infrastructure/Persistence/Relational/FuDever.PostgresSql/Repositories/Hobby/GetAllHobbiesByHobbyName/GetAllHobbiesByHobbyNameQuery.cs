using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Hobby.GetAllHobbiesByHobbyName;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Hobby.GetAllHobbiesByHobbyName.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Hobby.GetAllHobbiesByHobbyName;

internal sealed class GetAllHobbiesByHobbyNameQuery : IGetAllHobbiesByHobbyNameQuery
{
    private readonly GetAllHobbiesByHobbyNameStateBag _stateBag;

    internal GetAllHobbiesByHobbyNameQuery(GetAllHobbiesByHobbyNameStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<IEnumerable<Domain.Entities.Hobby>> GetAllHobbiesByHobbyNameQueryAsync(
        string hobbyName,
        CancellationToken cancellationToken
    )
    {
        // Linq-base
        return await _stateBag
            .Hobbies.AsNoTracking()
            .Where(predicate: hobby =>
                hobby.RemovedAt == CommonConstant.DbDefaultValue.MIN_DATE_TIME
                && hobby.RemovedBy
                    == Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && hobby.Id
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && EF.Functions.Collate(hobby.Name, CommonConstant.DbCollation.CASE_INSENSITIVE)
                    .Equals(hobbyName)
            )
            .Select(department => new Domain.Entities.Hobby
            {
                Id = department.Id,
                Name = department.Name
            })
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
