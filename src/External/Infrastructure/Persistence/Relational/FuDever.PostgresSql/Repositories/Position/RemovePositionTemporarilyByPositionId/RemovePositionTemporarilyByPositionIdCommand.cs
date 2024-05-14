using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Position.RemovePositionTemporarilyByPositionId;
using FuDever.PostgresSql.Repositories.Position.RemovePositionTemporarilyByPositionId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Position.RemovePositionTemporarilyByPositionId;

internal sealed class RemovePositionTemporarilyByPositionIdCommand
    : IRemovePositionTemporarilyByPositionIdCommand
{
    private readonly RemovePositionTemporarilyByPositionIdStateBag _stateBag;

    internal RemovePositionTemporarilyByPositionIdCommand(
        RemovePositionTemporarilyByPositionIdStateBag stateBag
    )
    {
        _stateBag = stateBag;
    }

    public async Task<bool> RemovePositionTemporarilyByPositionIdCommandAsync(
        Guid positionId,
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
                        .Positions.Where(predicate: position => position.Id == positionId)
                        .ExecuteUpdateAsync(
                            setPropertyCalls: updater =>
                                updater
                                    .SetProperty(position => position.RemovedAt, removedAt)
                                    .SetProperty(position => position.RemovedBy, removedBy),
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
