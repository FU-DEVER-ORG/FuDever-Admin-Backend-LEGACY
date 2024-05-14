using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Skill.UpdateSkillBySkillId;
using FuDever.PostgresSql.Repositories.Skill.UpdateSkillBySkillId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Skill.UpdateSkillBySkillId;

internal sealed class UpdateSkillBySkillIdCommand : IUpdateSkillBySkillIdCommand
{
    private readonly UpdateSkillBySkillIdStateBag _stateBag;

    internal UpdateSkillBySkillIdCommand(UpdateSkillBySkillIdStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> UpdateSkillBySkillIdCommandAsync(
        Guid skillId,
        string newSkillName,
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
                                updater.SetProperty(skill => skill.Name, newSkillName),
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
