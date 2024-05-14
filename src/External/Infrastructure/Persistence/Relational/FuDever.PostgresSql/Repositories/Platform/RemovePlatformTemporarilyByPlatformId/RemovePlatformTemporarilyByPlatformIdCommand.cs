using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Platform.RemovePlatformTemporarilyByPlatformId;
using FuDever.PostgresSql.Repositories.Platform.RemovePlatformTemporarilyByPlatformId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Platform.RemovePlatformTemporarilyByPlatformId;

internal sealed class RemovePlatformTemporarilyByPlatformIdCommand
    : IRemovePlatformTemporarilyByPlatformIdCommand
{
    private readonly RemovePlatformTemporarilyByPlatformIdStateBag _stateBag;

    internal RemovePlatformTemporarilyByPlatformIdCommand(
        RemovePlatformTemporarilyByPlatformIdStateBag stateBag
    )
    {
        _stateBag = stateBag;
    }

    public async Task<bool> RemovePlatformTemporarilyByPlatformIdCommandAsync(
        Guid platformId,
        Guid removedBy,
        DateTime removedAt,
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
                        .Platforms.Where(predicate: platform => platform.Id == platformId)
                        .ExecuteUpdateAsync(
                            setPropertyCalls: updater =>
                                updater
                                    .SetProperty(platform => platform.RemovedAt, removedAt)
                                    .SetProperty(platform => platform.RemovedBy, removedBy),
                            cancellationToken: cancellationToken
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
