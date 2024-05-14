using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Platform.GetAllPlatformsByPlatformName;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Platform.GetAllPlatformsByPlatformName.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Platform.GetAllPlatformsByPlatformName;

internal sealed class GetAllPlatformsByPlatformNameQuery : IGetAllPlatformsByPlatformNameQuery
{
    private readonly GetAllPlatformsByPlatformNameStateBag _stateBag;

    internal GetAllPlatformsByPlatformNameQuery(GetAllPlatformsByPlatformNameStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<
        IEnumerable<Domain.Entities.Platform>
    > GetAllPlatformsByPlatformNameQueryAsync(
        string platformName,
        CancellationToken cancellationToken
    )
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
                && EF.Functions.Collate(platform.Name, CommonConstant.DbCollation.CASE_INSENSITIVE)
                    .Equals(platformName)
            )
            .Select(selector: platform => new Domain.Entities.Platform
            {
                Id = platform.Id,
                Name = platform.Name
            })
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
