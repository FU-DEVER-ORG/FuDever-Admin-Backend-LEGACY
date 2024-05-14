using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Auth.Login;

public interface ILoginQuery
{
    Task<bool> IsUserNotTemporarilyRemovedQueryAsync(
        Guid userId,
        CancellationToken cancellationToken
    );

    Task<string> GetUserAvatarUrlQueryAsync(Guid userId, CancellationToken cancellationToken);

    Task<Entities.UserDetail> GetUserJoiningStatusQueryAsync(
        Guid userId,
        CancellationToken cancellationToken
    );
}
