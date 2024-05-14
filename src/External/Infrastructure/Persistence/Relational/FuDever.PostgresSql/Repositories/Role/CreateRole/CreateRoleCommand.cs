using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Role.CreateRole;
using FuDever.PostgresSql.Repositories.Role.CreateRole.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Role.CreateRole;

internal sealed class CreateRoleCommand : ICreateRoleCommand
{
    private readonly CreateRoleStateBag _stateBag;

    internal CreateRoleCommand(CreateRoleStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> CreateRoleCommandAsync(
        Domain.Entities.Role newRole,
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
                    await _stateBag.RoleManager.CreateAsync(role: newRole);

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
