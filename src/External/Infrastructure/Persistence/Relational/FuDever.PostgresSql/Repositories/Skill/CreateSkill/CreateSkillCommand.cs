using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Skill.CreateSkill;
using FuDever.PostgresSql.Repositories.Skill.CreateSkill.Others;

namespace FuDever.PostgresSql.Repositories.Skill.CreateSkill;

internal sealed class CreateSkillCommand : ICreateSkillCommand
{
    private readonly CreateSkillStateBag _stateBag;

    internal CreateSkillCommand(CreateSkillStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> CreateSkillCommandAsync(
        Domain.Entities.Skill newSkill,
        CancellationToken cancellationToken
    )
    {
        try
        {
            await _stateBag.Skills.AddAsync(entity: newSkill, cancellationToken: cancellationToken);

            await _stateBag.Context.SaveChangesAsync(cancellationToken: cancellationToken);
        }
        catch
        {
            return false;
        }

        return true;
    }
}
