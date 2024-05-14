using FuDever.Domain.Repositories.Position.RestorePositionByPositionId;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Position.RestorePositionByPositionId.Others;

internal sealed class RestorePositionByPositionIdRepository : IRestorePositionByPositionIdRepository
{
    private readonly RestorePositionByPositionIdStateBag _stateBag;
    private IRestorePositionByPositionIdCommand _commnad;
    private IRestorePositionByPositionIdQuery _query;

    internal RestorePositionByPositionIdRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IRestorePositionByPositionIdCommand Command
    {
        get { return _commnad ??= new RestorePositionByPositionIdCommand(stateBag: _stateBag); }
    }

    public IRestorePositionByPositionIdQuery Query
    {
        get { return _query ??= new RestorePositionByPositionIdQuery(stateBag: _stateBag); }
    }
}
