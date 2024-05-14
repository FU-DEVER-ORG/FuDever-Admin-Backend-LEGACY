using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Skill.RemoveSkillPermanentlyBySkillId;
using FuDever.PostgresSql.Repositories.Skill.RemoveSkillPermanentlyBySkillId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Skill.RemoveSkillPermanentlyBySkillId;

internal sealed class RemoveSkillPermanentlyBySkillIdCommand
    : IRemoveSkillPermanentlyBySkillIdCommand
{
    private readonly RemoveSkillPermanentlyBySkillIdStateBag _stateBag;

    internal RemoveSkillPermanentlyBySkillIdCommand(
        RemoveSkillPermanentlyBySkillIdStateBag stateBag
    )
    {
        _stateBag = stateBag;
    }

    public async Task<bool> RemoveSkillPermanentlyBySkillIdCommandAsync(
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
