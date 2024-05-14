using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Major.GetAllMajors;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Major.GetAllMajors.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Major.GetAllMajors;

internal sealed class GetAllMajorsQuery : IGetAllMajorsQuery
{
    private readonly GetAllMajorsStateBag _stateBag;

    internal GetAllMajorsQuery(GetAllMajorsStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<
        IEnumerable<Domain.Entities.Major>
    > GetAllNonTemporarilyRemovedMajorsQueryAsync(CancellationToken cancellationToken)
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
            )
            .Select(selector: major => new Domain.Entities.Major
            {
                Id = major.Id,
                Name = major.Name
            })
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
