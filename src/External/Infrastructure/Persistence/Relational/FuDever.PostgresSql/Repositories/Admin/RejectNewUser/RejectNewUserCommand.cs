using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Admin.RejectNewUser;
using FuDever.PostgresSql.Repositories.Admin.RejectNewUser.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Admin.RejectNewUser;

internal sealed class RejectNewUserCommand : IRejectNewUserCommand
{
    private readonly RejectNewUserStateBag _stateBag;

    internal RejectNewUserCommand(RejectNewUserStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> RejectUserCommandAsync(
        Guid userId,
        Guid rejectedUserJoiningStatusId,
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
                        .UserDetails.Where(predicate: userDetail => userDetail.Id == userId)
                        .ExecuteUpdateAsync(
                            setPropertyCalls: builder =>
                                builder.SetProperty(
                                    userDetail => userDetail.UserJoiningStatusId,
                                    rejectedUserJoiningStatusId
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
