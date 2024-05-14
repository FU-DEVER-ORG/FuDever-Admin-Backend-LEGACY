using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Role.UpdateRoleByRoleId;
using FuDever.PostgresSql.Repositories.Role.UpdateRoleByRoleId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Role.UpdateRoleByRoleId;

internal sealed class UpdateRoleByRoleIdCommand : IUpdateRoleByRoleIdCommand
{
    private readonly UpdateRoleByRoleIdStateBag _stateBag;

    internal UpdateRoleByRoleIdCommand(UpdateRoleByRoleIdStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> UpdateRoleByRoleIdCommandAsync(
        Guid roleId,
        string newRoleName,
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
                    await _stateBag.RoleManager.UpdateAsync(
                        new() { Id = roleId, Name = newRoleName }
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
