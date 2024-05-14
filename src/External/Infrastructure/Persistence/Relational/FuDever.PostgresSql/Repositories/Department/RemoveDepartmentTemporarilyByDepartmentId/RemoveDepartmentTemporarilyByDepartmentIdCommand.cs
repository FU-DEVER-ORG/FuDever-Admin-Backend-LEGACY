using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Department.RemoveDepartmentTemporarilyByDepartmentId;
using FuDever.PostgresSql.Repositories.Department.RemoveDepartmentTemporarilyByDepartmentId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Department.RemoveDepartmentTemporarilyByDepartmentId;

internal sealed class RemoveDepartmentTemporarilyByDepartmentIdCommand
    : IRemoveDepartmentTemporarilyByDepartmentIdCommand
{
    private readonly RemoveDepartmentTemporarilyByDepartmentIdStateBag _stateBag;

    public RemoveDepartmentTemporarilyByDepartmentIdCommand(
        RemoveDepartmentTemporarilyByDepartmentIdStateBag stateBag
    )
    {
        _stateBag = stateBag;
    }

    public async Task<bool> RemoveDepartmentTemporarilyByDepartmentIdCommandAsync(
        Guid departmentId,
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
                        .Departments.Where(predicate: department => department.Id == departmentId)
                        .ExecuteUpdateAsync(
                            setPropertyCalls: updater =>
                                updater
                                    .SetProperty(department => department.RemovedAt, removedAt)
                                    .SetProperty(department => department.RemovedBy, removedBy),
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
