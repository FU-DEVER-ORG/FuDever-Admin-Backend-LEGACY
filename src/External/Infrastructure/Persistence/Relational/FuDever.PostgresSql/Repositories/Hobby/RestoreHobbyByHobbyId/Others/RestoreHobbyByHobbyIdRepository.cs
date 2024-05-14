using FuDever.Domain.Repositories.Hobby.RestoreHobbyByHobbyId;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Hobby.RestoreHobbyByHobbyId.Others;

internal sealed class RestoreHobbyByHobbyIdRepository : IRestoreHobbyByHobbyIdRepository
{
    private readonly RestoreHobbyByHobbyIdStateBag _stateBag;
    private IRestoreHobbyByHobbyIdCommand _commnad;
    private IRestoreHobbyByHobbyIdQuery _query;

    internal RestoreHobbyByHobbyIdRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IRestoreHobbyByHobbyIdCommand Command
    {
        get { return _commnad ??= new RestoreHobbyByHobbyIdCommand(stateBag: _stateBag); }
    }

    public IRestoreHobbyByHobbyIdQuery Query
    {
        get { return _query ??= new RestoreHobbyByHobbyIdQuery(stateBag: _stateBag); }
    }
}
