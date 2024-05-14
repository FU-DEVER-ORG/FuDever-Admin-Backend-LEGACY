using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Role.GetAllRoles;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Role.GetAllRoles.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Role.GetAllRoles;

internal sealed class GetAllRolesQuery : IGetAllRolesQuery
{
    private readonly GetAllRolesStateBag _stateBag;

    internal GetAllRolesQuery(GetAllRolesStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<IEnumerable<Domain.Entities.Role>> GetAllNonTemporarilyRemovedRolesQueryAsync(
        CancellationToken cancellationToken
    )
    {
        // Linq-base
        return await _stateBag
            .RoleManager.Roles.AsNoTracking()
            .Where(predicate: role =>
                role.RemovedAt == CommonConstant.DbDefaultValue.MIN_DATE_TIME
                && role.RemovedBy
                    == Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && role.Id
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
            )
            .Select(selector: role => new Domain.Entities.Role { Id = role.Id, Name = role.Name })
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
