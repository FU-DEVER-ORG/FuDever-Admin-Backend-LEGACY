using FuDever.Domain.Repositories.Hobby.GetAllHobbies;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Hobby.GetAllHobbies.Others;

internal sealed class GetAllHobbiesRepository : IGetAllHobbiesRepository
{
    private readonly GetAllHobbiesStateBag _stateBag;
    private IGetAllHobbiesCommand _commnad;
    private IGetAllHobbiesQuery _query;

    internal GetAllHobbiesRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IGetAllHobbiesCommand Command
    {
        get { return _commnad ??= new GetAllHobbiesCommand(); }
    }

    public IGetAllHobbiesQuery Query
    {
        get { return _query ??= new GetAllHobbiesQuery(stateBag: _stateBag); }
    }
}
