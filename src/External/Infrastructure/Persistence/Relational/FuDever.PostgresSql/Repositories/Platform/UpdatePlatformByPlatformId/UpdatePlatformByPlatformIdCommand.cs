using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Platform.UpdatePlatformByPlatformId;
using FuDever.PostgresSql.Repositories.Platform.UpdatePlatformByPlatformId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Platform.UpdatePlatformByPlatformId;

internal sealed class UpdatePlatformByPlatformIdCommand : IUpdatePlatformByPlatformIdCommand
{
    private readonly UpdatePlatformByPlatformIdStateBag _stateBag;

    internal UpdatePlatformByPlatformIdCommand(UpdatePlatformByPlatformIdStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> UpdatePlatformByPlatformIdCommandAsync(
        Guid platformId,
        string newPlatformName,
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
                                updater.SetProperty(platform => platform.Name, newPlatformName),
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
