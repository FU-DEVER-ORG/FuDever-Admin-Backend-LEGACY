using FuDever.Domain.Repositories.Hobby.GetAllHobbiesByHobbyName;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Hobby.GetAllHobbiesByHobbyName.Others;

internal sealed class GetAllHobbiesByHobbyNameRepository : IGetAllHobbiesByHobbyNameRepository
{
    private readonly GetAllHobbiesByHobbyNameStateBag _stateBag;
    private IGetAllHobbiesByHobbyNameCommand _commnad;
    private IGetAllHobbiesByHobbyNameQuery _query;

    internal GetAllHobbiesByHobbyNameRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IGetAllHobbiesByHobbyNameCommand Command
    {
        get { return _commnad ??= new GetAllHobbiesByHobbyNameCommand(); }
    }

    public IGetAllHobbiesByHobbyNameQuery Query
    {
        get { return _query ??= new GetAllHobbiesByHobbyNameQuery(stateBag: _stateBag); }
    }
}
