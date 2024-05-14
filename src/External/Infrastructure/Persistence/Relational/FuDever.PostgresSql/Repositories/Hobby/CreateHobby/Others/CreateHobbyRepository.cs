using FuDever.Domain.Repositories.Hobby.CreateHobby;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Hobby.CreateHobby.Others;

internal sealed class CreateHobbyRepository : ICreateHobbyRepository
{
    private readonly CreateHobbyStateBag _stateBag;
    private ICreateHobbyQuery _query;
    private ICreateHobbyCommand _command;

    internal CreateHobbyRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public ICreateHobbyQuery Query
    {
        get { return _query ??= new CreateHobbyQuery(stateBag: _stateBag); }
    }

    public ICreateHobbyCommand Command
    {
        get { return _command ??= new CreateHobbyCommand(stateBag: _stateBag); }
    }
}
