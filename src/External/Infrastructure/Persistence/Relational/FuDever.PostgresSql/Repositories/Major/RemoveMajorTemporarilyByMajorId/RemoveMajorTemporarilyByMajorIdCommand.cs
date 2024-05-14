using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Major.RemoveMajorTemporarilyByMajorId;
using FuDever.PostgresSql.Repositories.Major.RemoveMajorTemporarilyByMajorId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Major.RemoveMajorTemporarilyByMajorId;

internal sealed class RemoveMajorTemporarilyByMajorIdCommand
    : IRemoveMajorTemporarilyByMajorIdCommand
{
    private readonly RemoveMajorTemporarilyByMajorIdStateBag _stateBag;

    internal RemoveMajorTemporarilyByMajorIdCommand(
        RemoveMajorTemporarilyByMajorIdStateBag stateBag
    )
    {
        _stateBag = stateBag;
    }

    public async Task<bool> RemoveMajorTemporarilyByMajorIdCommandAsync(
        Guid majorId,
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
                        .Majors.Where(predicate: major => major.Id == majorId)
                        .ExecuteUpdateAsync(
                            setPropertyCalls: updater =>
                                updater
                                    .SetProperty(major => major.RemovedAt, removedAt)
                                    .SetProperty(major => major.RemovedBy, removedBy),
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
