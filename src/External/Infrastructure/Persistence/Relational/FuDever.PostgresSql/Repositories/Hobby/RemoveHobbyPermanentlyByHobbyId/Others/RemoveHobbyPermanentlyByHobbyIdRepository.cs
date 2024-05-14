using FuDever.Domain.Repositories.Hobby.RemoveHobbyPermanentlyByHobbyId;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Hobby.RemoveHobbyPermanentlyByHobbyId.Others;

internal sealed class RemoveHobbyPermanentlyByHobbyIdRepository
    : IRemoveHobbyPermanentlyByHobbyIdRepository
{
    private readonly RemoveHobbyPermanentlyByHobbyIdStateBag _stateBag;
    private IRemoveHobbyPermanentlyByHobbyIdCommand _commnad;
    private IRemoveHobbyPermanentlyByHobbyIdQuery _query;

    internal RemoveHobbyPermanentlyByHobbyIdRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IRemoveHobbyPermanentlyByHobbyIdCommand Command
    {
        get { return _commnad ??= new RemoveHobbyPermanentlyByHobbyIdCommand(stateBag: _stateBag); }
    }

    public IRemoveHobbyPermanentlyByHobbyIdQuery Query
    {
        get { return _query ??= new RemoveHobbyPermanentlyByHobbyIdQuery(stateBag: _stateBag); }
    }
}
