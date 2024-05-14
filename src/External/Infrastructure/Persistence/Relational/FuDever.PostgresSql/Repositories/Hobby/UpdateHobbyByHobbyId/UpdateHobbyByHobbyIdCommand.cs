using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Hobby.UpdateHobbyByHobbyId;
using FuDever.PostgresSql.Repositories.Hobby.UpdateHobbyByHobbyId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Hobby.UpdateHobbyByHobbyId;

internal sealed class UpdateHobbyByHobbyIdCommand : IUpdateHobbyByHobbyIdCommand
{
    private readonly UpdateHobbyByHobbyIdStateBag _stateBag;

    internal UpdateHobbyByHobbyIdCommand(UpdateHobbyByHobbyIdStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> UpdateHobbyByHobbyIdCommandAsync(
        Guid hobbyId,
        string newHobbyName,
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
                                updater.SetProperty(hobby => hobby.Name, newHobbyName),
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
