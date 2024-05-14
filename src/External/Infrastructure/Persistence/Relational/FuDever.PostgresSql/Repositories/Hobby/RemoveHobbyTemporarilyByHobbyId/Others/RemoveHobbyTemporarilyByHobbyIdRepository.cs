using FuDever.Domain.Repositories.Hobby.RemoveHobbyTemporarilyByHobbyId;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Hobby.RemoveHobbyTemporarilyByHobbyId.Others;

internal sealed class RemoveHobbyTemporarilyByHobbyIdRepository
    : IRemoveHobbyTemporarilyByHobbyIdRepository
{
    private readonly RemoveHobbyTemporarilyByHobbyIdStateBag _stateBag;
    private IRemoveHobbyTemporarilyByHobbyIdCommand _commnad;
    private IRemoveHobbyTemporarilyByHobbyIdQuery _query;

    internal RemoveHobbyTemporarilyByHobbyIdRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IRemoveHobbyTemporarilyByHobbyIdCommand Command
    {
        get { return _commnad ??= new RemoveHobbyTemporarilyByHobbyIdCommand(stateBag: _stateBag); }
    }

    public IRemoveHobbyTemporarilyByHobbyIdQuery Query
    {
        get { return _query ??= new RemoveHobbyTemporarilyByHobbyIdQuery(stateBag: _stateBag); }
    }
}
