using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Department.CreateDepartment;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Department.CreateDepartment.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Department.CreateDepartment;

internal sealed class CreateDepartmentQuery : ICreateDepartmentQuery
{
    private readonly CreateDepartmentStateBag _stateBag;

    internal CreateDepartmentQuery(CreateDepartmentStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public Task<bool> IsDepartmentTemporarilyRemovedByDepartmentNameQueryAsync(
        string newDepartmentName,
        CancellationToken cancellationToken
    )
    {
        var minDateTimeInDatabase = CommonConstant.DbDefaultValue.MIN_DATE_TIME;

        // Linq-Base
        return _stateBag.Departments.AnyAsync(
            predicate: department =>
                EF.Functions.Collate(department.Name, CommonConstant.DbCollation.CASE_INSENSITIVE)
                    .Equals(newDepartmentName)
                && department.RemovedBy
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && department.RemovedAt != minDateTimeInDatabase,
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
