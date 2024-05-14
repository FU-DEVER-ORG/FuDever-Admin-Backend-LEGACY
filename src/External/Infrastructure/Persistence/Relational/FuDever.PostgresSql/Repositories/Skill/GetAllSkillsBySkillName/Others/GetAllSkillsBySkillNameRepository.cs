using FuDever.Domain.Repositories.Skill.GetAllSkillsBySkillName;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Skill.GetAllSkillsBySkillName.Others;

internal sealed class GetAllSkillsBySkillNameRepository : IGetAllSkillsBySkillNameRepository
{
    private readonly GetAllSkillsBySkillNameStateBag _stateBag;
    private IGetAllSkillsBySkillNameCommand _commnad;
    private IGetAllSkillsBySkillNameQuery _query;

    internal GetAllSkillsBySkillNameRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IGetAllSkillsBySkillNameCommand Command
    {
        get { return _commnad ??= new GetAllSkillsBySkillNameCommand(); }
    }

    public IGetAllSkillsBySkillNameQuery Query
    {
        get { return _query ??= new GetAllSkillsBySkillNameQuery(stateBag: _stateBag); }
    }
}
