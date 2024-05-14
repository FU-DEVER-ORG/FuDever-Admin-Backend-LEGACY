using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Position.GetAllPositions;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Position.GetAllPositions.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Position.GetAllPositions;

internal sealed class GetAllPositionsQuery : IGetAllPositionsQuery
{
    private readonly GetAllPositionsStateBag _stateBag;

    internal GetAllPositionsQuery(GetAllPositionsStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<
        IEnumerable<Domain.Entities.Position>
    > GetAllNonTemporarilyRemovedPositionsQueryAsync(CancellationToken cancellationToken)
    {
        // Linq-base
        return await _stateBag
            .Positions.AsNoTracking()
            .Where(predicate: position =>
                position.RemovedAt == CommonConstant.DbDefaultValue.MIN_DATE_TIME
                && position.RemovedBy
                    == Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && position.Id
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
            )
            .Select(selector: position => new Domain.Entities.Position
            {
                Id = position.Id,
                Name = position.Name
            })
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
