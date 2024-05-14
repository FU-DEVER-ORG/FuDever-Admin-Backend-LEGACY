using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Position.UpdatePositionByPositionId;
using FuDever.PostgresSql.Repositories.Position.UpdatePositionByPositionId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Position.UpdatePositionByPositionId;

internal sealed class UpdatePositionByPositionIdCommand : IUpdatePositionByPositionIdCommand
{
    private readonly UpdatePositionByPositionIdStateBag _stateBag;

    internal UpdatePositionByPositionIdCommand(UpdatePositionByPositionIdStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> UpdatePositionByPositionIdCommandAsync(
        Guid positionId,
        string newPositionName,
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
                                updater.SetProperty(position => position.Name, newPositionName),
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
