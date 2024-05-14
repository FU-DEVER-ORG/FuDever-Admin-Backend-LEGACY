using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Hobby.RestoreHobbyByHobbyId;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Hobby.RestoreHobbyByHobbyId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Hobby.RestoreHobbyByHobbyId;

internal sealed class RestoreHobbyByHobbyIdCommand : IRestoreHobbyByHobbyIdCommand
{
    private readonly RestoreHobbyByHobbyIdStateBag _stateBag;

    internal RestoreHobbyByHobbyIdCommand(RestoreHobbyByHobbyIdStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> RestoreHobbyByHobbyIdCommandAsync(
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
                        .ExecuteUpdateAsync(
                            setPropertyCalls: updater =>
                                updater
                                    .SetProperty(
                                        hobby => hobby.RemovedAt,
                                        CommonConstant.DbDefaultValue.MIN_DATE_TIME
                                    )
                                    .SetProperty(
                                        hobby => hobby.RemovedBy,
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
