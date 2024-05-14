using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Position.RemovePositionPermanentlyByPositionId;
using FuDever.PostgresSql.Repositories.Position.RemovePositionPermanentlyByPositionId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Position.RemovePositionPermanentlyByPositionId;

internal sealed class RemovePositionPermanentlyByPositionIdCommand
    : IRemovePositionPermanentlyByPositionIdCommand
{
    private readonly RemovePositionPermanentlyByPositionIdStateBag _stateBag;

    internal RemovePositionPermanentlyByPositionIdCommand(
        RemovePositionPermanentlyByPositionIdStateBag stateBag
    )
    {
        _stateBag = stateBag;
    }

    public async Task<bool> RemovePositionPermanentlyByPositionIdCommandAsync(
        Guid positionId,
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
