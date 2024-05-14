using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Entities;
using FuDever.Domain.Repositories.User.GetAllUsers;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.User.GetAllUsers.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.User.GetAllUsers;

internal sealed class GetAllUsersQuery : IGetAllUsersQuery
{
    private readonly GetAllUsersStateBag _stateBag;

    internal GetAllUsersQuery(GetAllUsersStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<IEnumerable<UserDetail>> GetAllNonTemporarilyRemovedUsersQueryAsync(
        CancellationToken cancellationToken
    )
    {
        return await _stateBag
            .UserDetails.AsNoTracking()
            .Where(predicate: userDetail =>
                userDetail.RemovedAt == CommonConstant.DbDefaultValue.MIN_DATE_TIME
                && userDetail.RemovedBy
                    == Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
            )
            .Select(selector: userDetail => new UserDetail
            {
                Id = userDetail.Id,
                User = new() { Email = userDetail.User.Email },
                FirstName = userDetail.FirstName,
                LastName = userDetail.LastName,
                Position = new() { Name = userDetail.Position.Name },
                Department = new() { Name = userDetail.Department.Name },
                UserJoiningStatus = new() { Type = userDetail.UserJoiningStatus.Type },
                AvatarUrl = userDetail.AvatarUrl
            })
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
