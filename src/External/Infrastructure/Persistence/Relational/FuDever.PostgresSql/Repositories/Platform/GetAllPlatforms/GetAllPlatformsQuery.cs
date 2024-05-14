using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Platform.GetAllPlatforms;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Platform.GetAllPlatforms.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Platform.GetAllPlatforms;

internal sealed class GetAllPlatformsQuery : IGetAllPlatformsQuery
{
    private readonly GetAllPlatformsStateBag _stateBag;

    internal GetAllPlatformsQuery(GetAllPlatformsStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<
        IEnumerable<Domain.Entities.Platform>
    > GetAllNonTemporarilyRemovedPlatformsQueryAsync(CancellationToken cancellationToken)
    {
        // Linq-base
        return await _stateBag
            .Platforms.AsNoTracking()
            .Where(predicate: platform =>
                platform.RemovedAt == CommonConstant.DbDefaultValue.MIN_DATE_TIME
                && platform.RemovedBy
                    == Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && platform.Id
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
            )
            .Select(selector: platform => new Domain.Entities.Platform
            {
                Id = platform.Id,
                Name = platform.Name
            })
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
