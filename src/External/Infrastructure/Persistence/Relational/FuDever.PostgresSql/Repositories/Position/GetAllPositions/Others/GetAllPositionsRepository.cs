using FuDever.Domain.Repositories.Position.GetAllPositions;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Position.GetAllPositions.Others;

internal sealed class GetAllPositionsRepository : IGetAllPositionsRepository
{
    private readonly GetAllPositionsStateBag _stateBag;
    private IGetAllPositionsQuery _query;
    private IGetAllPositionsCommand _command;

    internal GetAllPositionsRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IGetAllPositionsQuery Query
    {
        get { return _query ??= new GetAllPositionsQuery(stateBag: _stateBag); }
    }

    public IGetAllPositionsCommand Command
    {
        get { return _command ??= new GetAllPositionsCommand(); }
    }
}
