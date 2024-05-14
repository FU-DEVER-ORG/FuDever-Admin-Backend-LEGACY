using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Role.RemoveRoleTemporarilyByRoleId;
using FuDever.PostgresSql.Repositories.Role.RemoveRoleTemporarilyByRoleId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Role.RemoveRoleTemporarilyByRoleId;

internal sealed class RemoveRoleTemporarilyByRoleIdCommand : IRemoveRoleTemporarilyByRoleIdCommand
{
    private readonly RemoveRoleTemporarilyByRoleIdStateBag _stateBag;

    internal RemoveRoleTemporarilyByRoleIdCommand(RemoveRoleTemporarilyByRoleIdStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> RemoveRoleTemporarilyByRoleIdCommandAsync(
        Guid roleId,
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
                        .RoleManager.Roles.Where(predicate: role => role.Id == roleId)
                        .ExecuteUpdateAsync(
                            setPropertyCalls: updater =>
                                updater
                                    .SetProperty(role => role.RemovedAt, removedAt)
                                    .SetProperty(role => role.RemovedBy, removedBy),
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
