using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Auth.ChangingPassword;
using FuDever.PostgresSql.Repositories.Auth.ChangingPassword.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Auth.ChangingPassword;

internal sealed class ChangingPasswordCommand : IChangingPasswordCommand
{
    private readonly ChangingPasswordStateBag _stateBag;

    internal ChangingPasswordCommand(ChangingPasswordStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> RemoveUserResetPasswordTokenCommandAsync(
        string resetPasswordToken,
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
                        .UserTokens.Where(predicate: userToken =>
                            userToken.Value.Equals(resetPasswordToken)
                        )
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
