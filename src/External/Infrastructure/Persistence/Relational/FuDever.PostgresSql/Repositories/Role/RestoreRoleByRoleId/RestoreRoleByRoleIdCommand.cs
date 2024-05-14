using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Role.RestoreRoleByRoleId;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Role.RestoreRoleByRoleId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Role.RestoreRoleByRoleId;

internal sealed class RestoreRoleByRoleIdCommand : IRestoreRoleByRoleIdCommand
{
    private readonly RestoreRoleByRoleIdStateBag _stateBag;

    internal RestoreRoleByRoleIdCommand(RestoreRoleByRoleIdStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> RestoreRoleByRoleIdCommandAsync(
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
                    await _stateBag.RoleManager.UpdateAsync(
                        new()
                        {
                            Id = roleId,
                            RemovedAt = CommonConstant.DbDefaultValue.MIN_DATE_TIME,
                            RemovedBy = Application
                                .Shared
                                .Commons
                                .CommonConstant
                                .App
                                .DEFAULT_ENTITY_ID_AS_GUID
                        }
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
