using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Admin.ApproveNewUser;
using FuDever.PostgresSql.Repositories.Admin.ApproveNewUser.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Admin.ApproveNewUser;

internal sealed class ApproveNewUserCommand : IApproveNewUserCommand
{
    private readonly ApproveNewUserStateBag _stateBag;

    internal ApproveNewUserCommand(ApproveNewUserStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> ApproveUserCommandAsync(
        Guid userId,
        Guid approvedUserJoiningStatusId,
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
                                    approvedUserJoiningStatusId
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
