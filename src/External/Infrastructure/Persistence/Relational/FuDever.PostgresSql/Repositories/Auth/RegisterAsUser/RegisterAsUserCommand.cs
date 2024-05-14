using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Auth.RegisterAsUser;
using FuDever.PostgresSql.Repositories.Auth.RegisterAsUser.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Auth.RegisterAsUser;

internal sealed class RegisterAsUserCommand : IRegisterAsUserCommand
{
    private readonly RegisterAsUserStateBag _stateBag;

    internal RegisterAsUserCommand(RegisterAsUserStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> CreateAndAddUserToRoleCommandAsync(
        Domain.Entities.User newUser,
        string userPassword,
        string userRole,
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
                    var result = await _stateBag.UserManager.CreateAsync(
                        user: newUser,
                        password: userPassword
                    );

                    if (!result.Succeeded)
                    {
                        throw new DbUpdateConcurrencyException();
                    }

                    result = await _stateBag.UserManager.AddToRoleAsync(
                        user: newUser,
                        role: userRole
                    );

                    if (!result.Succeeded)
                    {
                        throw new DbUpdateConcurrencyException();
                    }

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
