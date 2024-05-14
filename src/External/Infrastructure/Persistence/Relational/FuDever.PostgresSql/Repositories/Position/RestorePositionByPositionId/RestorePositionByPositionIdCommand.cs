using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Position.RestorePositionByPositionId;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Position.RestorePositionByPositionId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Position.RestorePositionByPositionId;

internal sealed class RestorePositionByPositionIdCommand : IRestorePositionByPositionIdCommand
{
    private readonly RestorePositionByPositionIdStateBag _stateBag;

    internal RestorePositionByPositionIdCommand(RestorePositionByPositionIdStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> RestorePositionByPositionIdCommandAsync(
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
                        .ExecuteUpdateAsync(
                            setPropertyCalls: updater =>
                                updater
                                    .SetProperty(
                                        position => position.RemovedAt,
                                        CommonConstant.DbDefaultValue.MIN_DATE_TIME
                                    )
                                    .SetProperty(
                                        position => position.RemovedBy,
                                        Application
                                            .Shared
                                            .Commons
                                            .CommonConstant
                                            .App
                                            .DEFAULT_ENTITY_ID_AS_GUID
                                    ),
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
