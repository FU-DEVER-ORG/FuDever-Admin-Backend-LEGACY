using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Major.UpdateMajorByMajorId;
using FuDever.PostgresSql.Repositories.Major.UpdateMajorByMajorId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Major.UpdateMajorByMajorId;

internal sealed class UpdateMajorByMajorIdCommand : IUpdateMajorByMajorIdCommand
{
    private readonly UpdateMajorByMajorIdStateBag _stateBag;

    internal UpdateMajorByMajorIdCommand(UpdateMajorByMajorIdStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> UpdateMajorByMajorIdCommandAsync(
        Guid majorId,
        string newMajorName,
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
                                updater.SetProperty(major => major.Name, newMajorName),
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
