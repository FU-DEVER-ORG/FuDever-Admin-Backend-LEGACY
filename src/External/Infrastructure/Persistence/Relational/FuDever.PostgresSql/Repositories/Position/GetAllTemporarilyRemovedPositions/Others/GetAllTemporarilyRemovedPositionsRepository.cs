using FuDever.Domain.Repositories.Position.GetAllTemporarilyRemovedPositions;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Position.GetAllTemporarilyRemovedPositions.Others;

internal sealed class GetAllTemporarilyRemovedPositionsRepository
    : IGetAllTemporarilyRemovedPositionsRepository
{
    private readonly GetAllTemporarilyRemovedPositionsStateBag _stateBag;
    private IGetAllTemporarilyRemovedPositionsCommand _commnad;
    private IGetAllTemporarilyRemovedPositionsQuery _query;

    internal GetAllTemporarilyRemovedPositionsRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IGetAllTemporarilyRemovedPositionsCommand Command
    {
        get { return _commnad ??= new GetAllTemporarilyRemovedPositionsCommand(); }
    }

    public IGetAllTemporarilyRemovedPositionsQuery Query
    {
        get { return _query ??= new GetAllTemporarilyRemovedPositionsQuery(stateBag: _stateBag); }
    }
}
