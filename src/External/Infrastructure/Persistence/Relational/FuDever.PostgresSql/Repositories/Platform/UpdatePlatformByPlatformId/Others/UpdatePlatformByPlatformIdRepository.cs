using FuDever.Domain.Repositories.Platform.UpdatePlatformByPlatformId;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Platform.UpdatePlatformByPlatformId.Others;

internal sealed class UpdatePlatformByPlatformIdRepository : IUpdatePlatformByPlatformIdRepository
{
    private readonly UpdatePlatformByPlatformIdStateBag _stateBag;
    private IUpdatePlatformByPlatformIdCommand _commnad;
    private IUpdatePlatformByPlatformIdQuery _query;

    internal UpdatePlatformByPlatformIdRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IUpdatePlatformByPlatformIdCommand Command
    {
        get { return _commnad ??= new UpdatePlatformByPlatformIdCommand(stateBag: _stateBag); }
    }

    public IUpdatePlatformByPlatformIdQuery Query
    {
        get { return _query ??= new UpdatePlatformByPlatformIdQuery(stateBag: _stateBag); }
    }
}
