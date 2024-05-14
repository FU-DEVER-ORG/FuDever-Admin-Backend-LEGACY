using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Department.GetAllTemporarilyRemovedDepartments;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Department.GetAllTemporarilyRemovedDepartments.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Department.GetAllTemporarilyRemovedDepartments;

internal sealed class GetAllTemporarilyRemovedDepartmentsQuery
    : IGetAllTemporarilyRemovedDepartmentsQuery
{
    private readonly GetAllTemporarilyRemovedDepartmentsStateBag _stateBag;

    internal GetAllTemporarilyRemovedDepartmentsQuery(
        GetAllTemporarilyRemovedDepartmentsStateBag stateBag
    )
    {
        _stateBag = stateBag;
    }

    public async Task<
        IEnumerable<Domain.Entities.Department>
    > GetAllTemporarilyRemovedDepartmentsQueryAsync(CancellationToken cancellationToken)
    {
        // Linq-base
        return await _stateBag
            .Departments.AsNoTracking()
            .Where(predicate: department =>
                department.RemovedAt != CommonConstant.DbDefaultValue.MIN_DATE_TIME
                && department.RemovedBy
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && department.Id
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
            )
            .Select(department => new Domain.Entities.Department
            {
                Id = department.Id,
                Name = department.Name,
                RemovedAt = department.RemovedAt,
                RemovedBy = department.RemovedBy
            })
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public Task<bool> IsRefreshTokenFoundByAccessTokenIdQueryAsync(
        Guid accessTokenId,
        CancellationToken cancellationToken
    )
    {
        // Linq-Base
        return _stateBag.RefreshTokens.AnyAsync(
            predicate: refreshToken => refreshToken.AccessTokenId == accessTokenId,
            cancellationToken: cancellationToken
        );
    }

    public Task<bool> IsUserNotTemporarilyRemovedQueryAsync(
        Guid userId,
        CancellationToken cancellationToken
    )
    {
        var minDateTimeInDatabase = CommonConstant.DbDefaultValue.MIN_DATE_TIME;

        // Linq-Base
        return _stateBag.UserDetails.AnyAsync(
            predicate: user =>
                user.Id == userId
                && user.RemovedBy
                    == Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && user.RemovedAt == minDateTimeInDatabase,
            cancellationToken: cancellationToken
        );
    }
}
