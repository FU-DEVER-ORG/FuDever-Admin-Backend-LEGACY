using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Major.RemoveMajorPermanentlyByMajorId;
using FuDever.PostgresSql.Repositories.Major.RemoveMajorPermanentlyByMajorId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Major.RemoveMajorPermanentlyByMajorId;

internal sealed class RemoveMajorPermanentlyByMajorIdCommand
    : IRemoveMajorPermanentlyByMajorIdCommand
{
    private readonly RemoveMajorPermanentlyByMajorIdStateBag _stateBag;

    internal RemoveMajorPermanentlyByMajorIdCommand(
        RemoveMajorPermanentlyByMajorIdStateBag stateBag
    )
    {
        _stateBag = stateBag;
    }

    public async Task<bool> RemoveMajorPermanentlyByMajorIdCommandAsync(
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
