using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Department.RemoveDepartmentPermanentlyByDepartmentId;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Department.RemoveDepartmentPermanentlyByDepartmentId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Department.RemoveDepartmentPermanentlyByDepartmentId;

internal sealed class RemoveDepartmentPermanentlyByDepartmentIdQuery
    : IRemoveDepartmentPermanentlyByDepartmentIdQuery
{
    private readonly RemoveDepartmentPermanentlyByDepartmentIdStateBag _stateBag;

    public RemoveDepartmentPermanentlyByDepartmentIdQuery(
        RemoveDepartmentPermanentlyByDepartmentIdStateBag stateBag
    )
    {
        _stateBag = stateBag;
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
