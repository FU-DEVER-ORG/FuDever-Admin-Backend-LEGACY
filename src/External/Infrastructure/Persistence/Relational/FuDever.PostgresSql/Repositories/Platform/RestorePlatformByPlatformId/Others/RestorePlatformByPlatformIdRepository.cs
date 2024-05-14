using FuDever.Domain.Repositories.Platform.RestorePlatformByPlatformId;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Platform.RestorePlatformByPlatformId.Others;

internal sealed class RestorePlatformByPlatformIdRepository : IRestorePlatformByPlatformIdRepository
{
    private readonly RestorePlatformByPlatformIdStateBag _stateBag;
    private IRestorePlatformByPlatformIdCommand _commnad;
    private IRestorePlatformByPlatformIdQuery _query;

    internal RestorePlatformByPlatformIdRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IRestorePlatformByPlatformIdCommand Command
    {
        get { return _commnad ??= new RestorePlatformByPlatformIdCommand(stateBag: _stateBag); }
    }

    public IRestorePlatformByPlatformIdQuery Query
    {
        get { return _query ??= new RestorePlatformByPlatformIdQuery(stateBag: _stateBag); }
    }
}
