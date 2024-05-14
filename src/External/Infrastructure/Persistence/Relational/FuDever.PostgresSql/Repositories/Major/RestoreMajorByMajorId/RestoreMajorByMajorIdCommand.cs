using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Major.RestoreMajorByMajorId;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Major.RestoreMajorByMajorId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Major.RestoreMajorByMajorId;

internal sealed class RestoreMajorByMajorIdCommand : IRestoreMajorByMajorIdCommand
{
    private readonly RestoreMajorByMajorIdStateBag _stateBag;

    internal RestoreMajorByMajorIdCommand(RestoreMajorByMajorIdStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> RestoreMajorByMajorIdCommandAsync(
        Guid majorId,
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
                        .Majors.Where(predicate: major => major.Id == majorId)
                        .ExecuteUpdateAsync(
                            setPropertyCalls: updater =>
                                updater
                                    .SetProperty(
                                        major => major.RemovedAt,
                                        CommonConstant.DbDefaultValue.MIN_DATE_TIME
                                    )
                                    .SetProperty(
                                        major => major.RemovedBy,
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
