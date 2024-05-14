using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Department.UpdateDepartmentByDepartmentId;
using FuDever.PostgresSql.Repositories.Department.UpdateDepartmentByDepartmentId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Department.UpdateDepartmentByDepartmentId;

internal sealed class UpdateDepartmentByDepartmentIdCommand : IUpdateDepartmentByDepartmentIdCommand
{
    private readonly UpdateDepartmentByDepartmentIdStateBag _stateBag;

    public UpdateDepartmentByDepartmentIdCommand(UpdateDepartmentByDepartmentIdStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> UpdateDepartmentByDepartmentIdCommandAsync(
        Guid departmentId,
        string newDepartmentName,
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
                                updater.SetProperty(
                                    department => department.Name,
                                    newDepartmentName
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
