using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Department.UpdateDepartmentByDepartmentId;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Department.UpdateDepartmentByDepartmentId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Department.UpdateDepartmentByDepartmentId;

internal sealed class UpdateDepartmentByDepartmentIdQuery : IUpdateDepartmentByDepartmentIdQuery
{
    private readonly UpdateDepartmentByDepartmentIdStateBag _stateBag;

    public UpdateDepartmentByDepartmentIdQuery(UpdateDepartmentByDepartmentIdStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public Task<Domain.Entities.Department> FindDepartmentByDepartmentIdForCacheClearing(
        Guid departmentId,
        CancellationToken cancellationToken
    )
    {
        return _stateBag
            .Departments.AsNoTracking()
            .Where(predicate: department => department.Id == departmentId)
            .Select(selector: department => new Domain.Entities.Department
            {
                Name = department.Name
            })
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public Task<bool> IsDepartmentFoundByDepartmentIdQueryAsync(
        Guid departmentId,
        CancellationToken cancellationToken
    )
    {
        // Linq-Base
        return _stateBag.Departments.AnyAsync(
            department => department.Id == departmentId,
            cancellationToken: cancellationToken
        );
    }

    public Task<bool> IsDepartmentTemporarilyRemovedByDepartmentIdQueryAsync(
        Guid departmentId,
        CancellationToken cancellationToken
    )
    {
        // Linq-Base
        return _stateBag.Departments.AnyAsync(
            department =>
                department.RemovedBy
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && department.RemovedAt != CommonConstant.DbDefaultValue.MIN_DATE_TIME,
            cancellationToken: cancellationToken
        );
    }

    public Task<bool> IsDepartmentWithTheSameNameFoundByDepartmentNameQueryAsync(
        string newDepartmentName,
        CancellationToken cancellationToken
    )
    {
        // Linq-Base
        return _stateBag.Departments.AnyAsync(
            predicate: department =>
                EF.Functions.Collate(department.Name, CommonConstant.DbCollation.CASE_INSENSITIVE)
                    .Equals(newDepartmentName),
            cancellationToken: cancellationToken
        );
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
