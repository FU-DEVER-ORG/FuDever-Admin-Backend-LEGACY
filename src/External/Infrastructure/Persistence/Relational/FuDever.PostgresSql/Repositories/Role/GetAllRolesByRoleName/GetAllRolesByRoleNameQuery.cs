using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Role.GetAllRolesByRoleName;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Role.GetAllRolesByRoleName.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Role.GetAllRolesByRoleName;

internal sealed class GetAllRolesByRoleNameQuery : IGetAllRolesByRoleNameQuery
{
    private readonly GetAllRolesByRoleNameStateBag _stateBag;

    internal GetAllRolesByRoleNameQuery(GetAllRolesByRoleNameStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<IEnumerable<Domain.Entities.Role>> GetAllRolesByRoleNameQueryAsync(
        string roleName,
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
                && EF.Functions.Collate(role.Name, CommonConstant.DbCollation.CASE_INSENSITIVE)
                    .Equals(roleName)
            )
            .Select(selector: role => new Domain.Entities.Role { Id = role.Id, Name = role.Name })
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
