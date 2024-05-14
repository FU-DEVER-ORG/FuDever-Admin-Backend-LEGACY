using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Role.RemoveRolePermanentlyByRoleId;
using FuDever.PostgresSql.Repositories.Role.RemoveRolePermanentlyByRoleId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Role.RemoveRolePermanentlyByRoleId;

internal sealed class RemoveRolePermanentlyByRoleIdCommand : IRemoveRolePermanentlyByRoleIdCommand
{
    private readonly RemoveRolePermanentlyByRoleIdStateBag _stateBag;

    internal RemoveRolePermanentlyByRoleIdCommand(RemoveRolePermanentlyByRoleIdStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> RemoveRolePermanentlyByRoleIdCommandAsync(
        Guid roleId,
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
                    await _stateBag.RoleManager.DeleteAsync(role: new() { Id = roleId });

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
