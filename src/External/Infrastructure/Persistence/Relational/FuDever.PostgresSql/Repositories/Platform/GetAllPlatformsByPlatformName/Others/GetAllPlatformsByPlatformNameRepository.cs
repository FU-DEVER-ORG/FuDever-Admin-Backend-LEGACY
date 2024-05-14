using FuDever.Domain.Repositories.Platform.GetAllPlatformsByPlatformName;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Platform.GetAllPlatformsByPlatformName.Others;

internal sealed class GetAllPlatformsByPlatformNameRepository
    : IGetAllPlatformsByPlatformNameRepository
{
    private readonly GetAllPlatformsByPlatformNameStateBag _stateBag;
    private IGetAllPlatformsByPlatformNameCommand _commnad;
    private IGetAllPlatformsByPlatformNameQuery _query;

    internal GetAllPlatformsByPlatformNameRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IGetAllPlatformsByPlatformNameCommand Command
    {
        get { return _commnad ??= new GetAllPlatformsByPlatformNameCommand(); }
    }

    public IGetAllPlatformsByPlatformNameQuery Query
    {
        get { return _query ??= new GetAllPlatformsByPlatformNameQuery(stateBag: _stateBag); }
    }
}
