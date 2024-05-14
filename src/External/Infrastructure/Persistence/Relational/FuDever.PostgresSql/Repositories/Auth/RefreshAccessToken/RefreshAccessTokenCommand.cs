using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Auth.RefreshAccessToken;
using FuDever.PostgresSql.Repositories.Auth.RefreshAccessToken.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Auth.RefreshAccessToken;

internal sealed class RefreshAccessTokenCommand : IRefreshAccessTokenCommand
{
    private readonly RefreshAccessTokenStateBag _stateBag;

    internal RefreshAccessTokenCommand(RefreshAccessTokenStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> UpdateRefreshTokenCommandAsync(
        string oldRefreshTokenValue,
        string newRefreshTokenValue,
        Guid newAccessTokenId,
        CancellationToken cancellationToken
    )
    {
        var executedTransactionResult = false;

        await _stateBag
            .Context.Database.CreateExecutionStrategy()
            .ExecuteAsync(operation: async () =>
            {
                using var transaction = await _stateBag.Context.Database.BeginTransactionAsync(
                    cancellationToken: cancellationToken
                );

                try
                {
                    await _stateBag
                        .RefreshTokens.Where(predicate: refreshToken =>
                            refreshToken.RefreshTokenValue.Equals(oldRefreshTokenValue)
                        )
                        .ExecuteUpdateAsync(setPropertyCalls: builder =>
                            builder
                                .SetProperty(
                                    refreshToken => refreshToken.AccessTokenId,
                                    newAccessTokenId
                                )
                                .SetProperty(
                                    refreshToken => refreshToken.RefreshTokenValue,
                                    newRefreshTokenValue
                                )
                        );

                    await transaction.CommitAsync(cancellationToken: cancellationToken);

                    executedTransactionResult = true;
                }
                catch
                {
                    await transaction.RollbackAsync(cancellationToken: cancellationToken);
                }
            });

        return executedTransactionResult;
    }
}
