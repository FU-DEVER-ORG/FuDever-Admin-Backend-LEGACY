using FuDever.Domain.Repositories.Hobby.GetAllTemporarilyRemovedHobbies;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Hobby.GetAllTemporarilyRemovedHobbies.Others;

internal sealed class GetAllTemporarilyRemovedHobbiesRepository
    : IGetAllTemporarilyRemovedHobbiesRepository
{
    private readonly GetAllTemporarilyRemovedHobbiesStateBag _stateBag;
    private IGetAllTemporarilyRemovedHobbiesCommand _commnad;
    private IGetAllTemporarilyRemovedHobbiesQuery _query;

    internal GetAllTemporarilyRemovedHobbiesRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IGetAllTemporarilyRemovedHobbiesCommand Command
    {
        get { return _commnad ??= new GetAllTemporarilyRemovedHobbiesCommand(); }
    }

    public IGetAllTemporarilyRemovedHobbiesQuery Query
    {
        get { return _query ??= new GetAllTemporarilyRemovedHobbiesQuery(stateBag: _stateBag); }
    }
}
