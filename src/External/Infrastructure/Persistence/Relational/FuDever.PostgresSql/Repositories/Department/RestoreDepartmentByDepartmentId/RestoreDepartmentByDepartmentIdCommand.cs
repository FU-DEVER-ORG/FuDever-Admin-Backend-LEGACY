using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Department.RestoreDepartmentByDepartmentId;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Department.RestoreDepartmentByDepartmentId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Department.RestoreDepartmentByDepartmentId;

internal sealed class RestoreDepartmentByDepartmentIdCommand
    : IRestoreDepartmentByDepartmentIdCommand
{
    private readonly RestoreDepartmentByDepartmentIdStateBag _stateBag;

    public RestoreDepartmentByDepartmentIdCommand(RestoreDepartmentByDepartmentIdStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> RestoreDepartmentByDepartmentIdCommandAsync(
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
                        .ExecuteUpdateAsync(
                            setPropertyCalls: updater =>
                                updater
                                    .SetProperty(
                                        department => department.RemovedAt,
                                        CommonConstant.DbDefaultValue.MIN_DATE_TIME
                                    )
                                    .SetProperty(
                                        department => department.RemovedBy,
                                        Application
                                            .Shared
                                            .Commons
                                            .CommonConstant
                                            .App
                                            .DEFAULT_ENTITY_ID_AS_GUID
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
