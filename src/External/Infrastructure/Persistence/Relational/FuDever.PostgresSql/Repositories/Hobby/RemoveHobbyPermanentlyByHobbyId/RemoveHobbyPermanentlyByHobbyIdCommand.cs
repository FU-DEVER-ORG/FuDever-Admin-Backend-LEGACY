using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Hobby.RemoveHobbyPermanentlyByHobbyId;
using FuDever.PostgresSql.Repositories.Hobby.RemoveHobbyPermanentlyByHobbyId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Hobby.RemoveHobbyPermanentlyByHobbyId;

internal sealed class RemoveHobbyPermanentlyByHobbyIdCommand
    : IRemoveHobbyPermanentlyByHobbyIdCommand
{
    private readonly RemoveHobbyPermanentlyByHobbyIdStateBag _stateBag;

    internal RemoveHobbyPermanentlyByHobbyIdCommand(
        RemoveHobbyPermanentlyByHobbyIdStateBag stateBag
    )
    {
        _stateBag = stateBag;
    }

    public async Task<bool> RemoveHobbyPermanentlyByHobbyIdCommandAsync(
        Guid hobbyId,
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
