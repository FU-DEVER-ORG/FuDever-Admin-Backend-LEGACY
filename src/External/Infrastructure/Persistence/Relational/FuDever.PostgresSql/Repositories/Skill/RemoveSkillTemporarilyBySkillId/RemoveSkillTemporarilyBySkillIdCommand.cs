using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Skill.RemoveSkillTemporarilyBySkillId;
using FuDever.PostgresSql.Repositories.Skill.RemoveSkillTemporarilyBySkillId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Skill.RemoveSkillTemporarilyBySkillId;

internal sealed class RemoveSkillTemporarilyBySkillIdCommand
    : IRemoveSkillTemporarilyBySkillIdCommand
{
    private readonly RemoveSkillTemporarilyBySkillIdStateBag _stateBag;

    internal RemoveSkillTemporarilyBySkillIdCommand(
        RemoveSkillTemporarilyBySkillIdStateBag stateBag
    )
    {
        _stateBag = stateBag;
    }

    public async Task<bool> RemoveSkillTemporarilyBySkillIdCommandAsync(
        Guid skillId,
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
                        .Skills.Where(predicate: skill => skill.Id == skillId)
                        .ExecuteUpdateAsync(
                            setPropertyCalls: updater =>
                                updater
                                    .SetProperty(skill => skill.RemovedAt, removedAt)
                                    .SetProperty(skill => skill.RemovedBy, removedBy),
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
