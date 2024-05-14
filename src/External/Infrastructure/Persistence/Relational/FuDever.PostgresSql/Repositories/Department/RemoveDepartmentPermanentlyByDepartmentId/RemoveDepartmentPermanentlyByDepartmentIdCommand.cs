using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Department.RemoveDepartmentPermanentlyByDepartmentId;
using FuDever.PostgresSql.Repositories.Department.RemoveDepartmentPermanentlyByDepartmentId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Department.RemoveDepartmentPermanentlyByDepartmentId;

internal sealed class RemoveDepartmentPermanentlyByDepartmentIdCommand
    : IRemoveDepartmentPermanentlyByDepartmentIdCommand
{
    private readonly RemoveDepartmentPermanentlyByDepartmentIdStateBag _stateBag;

    public RemoveDepartmentPermanentlyByDepartmentIdCommand(
        RemoveDepartmentPermanentlyByDepartmentIdStateBag stateBag
    )
    {
        _stateBag = stateBag;
    }

    public async Task<bool> RemoveDepartmentPermanentlyByDepartmentIdCommandAsync(
        Guid departmentId,
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
