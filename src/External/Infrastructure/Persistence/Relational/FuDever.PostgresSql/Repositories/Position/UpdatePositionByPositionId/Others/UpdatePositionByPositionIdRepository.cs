using FuDever.Domain.Repositories.Position.UpdatePositionByPositionId;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Position.UpdatePositionByPositionId.Others;

internal sealed class UpdatePositionByPositionIdRepository : IUpdatePositionByPositionIdRepository
{
    private readonly UpdatePositionByPositionIdStateBag _stateBag;
    private IUpdatePositionByPositionIdCommand _commnad;
    private IUpdatePositionByPositionIdQuery _query;

    internal UpdatePositionByPositionIdRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IUpdatePositionByPositionIdCommand Command
    {
        get { return _commnad ??= new UpdatePositionByPositionIdCommand(stateBag: _stateBag); }
    }

    public IUpdatePositionByPositionIdQuery Query
    {
        get { return _query ??= new UpdatePositionByPositionIdQuery(stateBag: _stateBag); }
    }
}
