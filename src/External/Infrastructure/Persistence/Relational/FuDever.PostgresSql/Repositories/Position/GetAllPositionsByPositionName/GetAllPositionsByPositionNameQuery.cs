using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Position.GetAllPositionsByPositionName;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Position.GetAllPositionsByPositionName.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Position.GetAllPositionsByPositionName;

internal sealed class GetAllPositionsByPositionNameQuery : IGetAllPositionsByPositionNameQuery
{
    private readonly GetAllPositionsByPositionNameStateBag _stateBag;

    internal GetAllPositionsByPositionNameQuery(GetAllPositionsByPositionNameStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<
        IEnumerable<Domain.Entities.Position>
    > GetAllPositionsByPositionNameQueryAsync(
        string positionName,
        CancellationToken cancellationToken
    )
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
                && EF.Functions.Collate(position.Name, CommonConstant.DbCollation.CASE_INSENSITIVE)
                    .Equals(positionName)
            )
            .Select(selector: position => new Domain.Entities.Position
            {
                Id = position.Id,
                Name = position.Name
            })
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
