using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Auth.RefreshAccessToken;

public interface IRefreshAccessTokenQuery
{
    Task<bool> IsRefreshTokenFoundByAccessTokenIdQueryAsync(
        Guid accessTokenId,
        CancellationToken cancellationToken
    );

    Task<bool> IsUserNotTemporarilyRemovedQueryAsync(
        Guid userId,
        CancellationToken cancellationToken
    );

    Task<Entities.RefreshToken> FindByRefreshTokenValueQueryAsync(
        string refreshTokenValue,
        CancellationToken cancellationToken
    );
}
