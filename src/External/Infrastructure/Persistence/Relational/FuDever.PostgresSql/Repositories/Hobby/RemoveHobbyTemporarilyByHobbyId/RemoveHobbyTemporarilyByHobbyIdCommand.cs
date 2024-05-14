using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Hobby.RemoveHobbyTemporarilyByHobbyId;
using FuDever.PostgresSql.Repositories.Hobby.RemoveHobbyTemporarilyByHobbyId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Hobby.RemoveHobbyTemporarilyByHobbyId;

internal sealed class RemoveHobbyTemporarilyByHobbyIdCommand
    : IRemoveHobbyTemporarilyByHobbyIdCommand
{
    private readonly RemoveHobbyTemporarilyByHobbyIdStateBag _stateBag;

    internal RemoveHobbyTemporarilyByHobbyIdCommand(
        RemoveHobbyTemporarilyByHobbyIdStateBag stateBag
    )
    {
        _stateBag = stateBag;
    }

    public async Task<bool> RemoveHobbyTemporarilyByHobbyIdCommandAsync(
        Guid hobbyId,
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
                        .Hobbies.Where(predicate: hobby => hobby.Id == hobbyId)
                        .ExecuteUpdateAsync(
                            setPropertyCalls: updater =>
                                updater
                                    .SetProperty(hobby => hobby.RemovedAt, removedAt)
                                    .SetProperty(hobby => hobby.RemovedBy, removedBy),
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
