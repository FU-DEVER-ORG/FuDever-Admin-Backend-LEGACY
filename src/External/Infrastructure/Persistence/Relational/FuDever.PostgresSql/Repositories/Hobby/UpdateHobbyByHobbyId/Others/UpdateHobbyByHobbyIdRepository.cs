using FuDever.Domain.Repositories.Hobby.UpdateHobbyByHobbyId;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Hobby.UpdateHobbyByHobbyId.Others;

internal sealed class UpdateHobbyByHobbyIdRepository : IUpdateHobbyByHobbyIdRepository
{
    private readonly UpdateHobbyByHobbyIdStateBag _stateBag;
    private IUpdateHobbyByHobbyIdCommand _commnad;
    private IUpdateHobbyByHobbyIdQuery _query;

    internal UpdateHobbyByHobbyIdRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IUpdateHobbyByHobbyIdCommand Command
    {
        get { return _commnad ??= new UpdateHobbyByHobbyIdCommand(stateBag: _stateBag); }
    }

    public IUpdateHobbyByHobbyIdQuery Query
    {
        get { return _query ??= new UpdateHobbyByHobbyIdQuery(stateBag: _stateBag); }
    }
}
