using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Hobby.GetAllHobbies;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Hobby.GetAllHobbies.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Hobby.GetAllHobbies;

internal sealed class GetAllHobbiesQuery : IGetAllHobbiesQuery
{
    private readonly GetAllHobbiesStateBag _stateBag;

    internal GetAllHobbiesQuery(GetAllHobbiesStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<
        IEnumerable<Domain.Entities.Hobby>
    > GetAllNonTemporarilyRemovedHobbiesQueryAsync(CancellationToken cancellationToken)
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
            )
            .Select(hobby => new Domain.Entities.Hobby { Id = hobby.Id, Name = hobby.Name })
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
