using FuDever.Domain.Repositories.Position.GetAllPositionsByPositionName;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Position.GetAllPositionsByPositionName.Others;

internal sealed class GetAllPositionsByPositionNameRepository
    : IGetAllPositionsByPositionNameRepository
{
    private readonly GetAllPositionsByPositionNameStateBag _stateBag;
    private IGetAllPositionsByPositionNameCommand _commnad;
    private IGetAllPositionsByPositionNameQuery _query;

    internal GetAllPositionsByPositionNameRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IGetAllPositionsByPositionNameCommand Command
    {
        get { return _commnad ??= new GetAllPositionsByPositionNameCommand(); }
    }

    public IGetAllPositionsByPositionNameQuery Query
    {
        get { return _query ??= new GetAllPositionsByPositionNameQuery(stateBag: _stateBag); }
    }
}
