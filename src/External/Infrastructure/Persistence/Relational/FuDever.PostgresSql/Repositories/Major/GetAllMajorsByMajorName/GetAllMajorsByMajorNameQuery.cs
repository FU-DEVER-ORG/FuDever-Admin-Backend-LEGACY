using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Major.GetAllMajorsByMajorName;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Major.GetAllMajorsByMajorName.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Major.GetAllMajorsByMajorName;

internal sealed class GetAllMajorsByMajorNameQuery : IGetAllMajorsByMajorNameQuery
{
    private readonly GetAllMajorsByMajorNameStateBag _stateBag;

    internal GetAllMajorsByMajorNameQuery(GetAllMajorsByMajorNameStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<IEnumerable<Domain.Entities.Major>> GetAllMajorsByMajorNameQueryAsync(
        string majorName,
        CancellationToken cancellationToken
    )
    {
        // Linq-base
        return await _stateBag
            .Majors.AsNoTracking()
            .Where(predicate: major =>
                major.RemovedAt == CommonConstant.DbDefaultValue.MIN_DATE_TIME
                && major.RemovedBy
                    == Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && major.Id
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && EF.Functions.Collate(major.Name, CommonConstant.DbCollation.CASE_INSENSITIVE)
                    .Equals(majorName)
            )
            .Select(selector: major => new Domain.Entities.Major
            {
                Id = major.Id,
                Name = major.Name
            })
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
