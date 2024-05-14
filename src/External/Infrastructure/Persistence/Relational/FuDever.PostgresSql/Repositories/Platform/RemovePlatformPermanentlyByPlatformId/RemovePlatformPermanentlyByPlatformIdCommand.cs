using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Platform.RemovePlatformPermanentlyByPlatformId;
using FuDever.PostgresSql.Repositories.Platform.RemovePlatformPermanentlyByPlatformId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Platform.RemovePlatformPermanentlyByPlatformId;

internal sealed class RemovePlatformPermanentlyByPlatformIdCommand
    : IRemovePlatformPermanentlyByPlatformIdCommand
{
    private readonly RemovePlatformPermanentlyByPlatformIdStateBag _stateBag;

    internal RemovePlatformPermanentlyByPlatformIdCommand(
        RemovePlatformPermanentlyByPlatformIdStateBag stateBag
    )
    {
        _stateBag = stateBag;
    }

    public async Task<bool> RemovePlatformPermanentlyByPlatformIdCommandAsync(
        Guid platformId,
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
                        .ExecuteDeleteAsync(cancellationToken: cancellationToken);

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
