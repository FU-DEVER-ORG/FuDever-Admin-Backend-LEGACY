using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Platform.RestorePlatformByPlatformId;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Platform.RestorePlatformByPlatformId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Platform.RestorePlatformByPlatformId;

internal sealed class RestorePlatformByPlatformIdCommand : IRestorePlatformByPlatformIdCommand
{
    private readonly RestorePlatformByPlatformIdStateBag _stateBag;

    internal RestorePlatformByPlatformIdCommand(RestorePlatformByPlatformIdStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> RestorePlatformByPlatformIdCommandAsync(
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
                        .ExecuteUpdateAsync(
                            setPropertyCalls: updater =>
                                updater
                                    .SetProperty(
                                        platform => platform.RemovedAt,
                                        CommonConstant.DbDefaultValue.MIN_DATE_TIME
                                    )
                                    .SetProperty(
                                        platform => platform.RemovedBy,
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
