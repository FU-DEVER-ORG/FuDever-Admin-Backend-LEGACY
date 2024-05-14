using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Skill.RestoreSkillBySkillId;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Skill.RestoreSkillBySkillId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Skill.RestoreSkillBySkillId;

internal sealed class RestoreSkillBySkillIdCommand : IRestoreSkillBySkillIdCommand
{
    private readonly RestoreSkillBySkillIdStateBag _stateBag;

    internal RestoreSkillBySkillIdCommand(RestoreSkillBySkillIdStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> RestoreSkillBySkillIdCommandAsync(
        Guid skillId,
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
                        .Skills.Where(predicate: skill => skill.Id == skillId)
                        .ExecuteUpdateAsync(
                            setPropertyCalls: updater =>
                                updater
                                    .SetProperty(
                                        skill => skill.RemovedAt,
                                        CommonConstant.DbDefaultValue.MIN_DATE_TIME
                                    )
                                    .SetProperty(
                                        skill => skill.RemovedBy,
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
