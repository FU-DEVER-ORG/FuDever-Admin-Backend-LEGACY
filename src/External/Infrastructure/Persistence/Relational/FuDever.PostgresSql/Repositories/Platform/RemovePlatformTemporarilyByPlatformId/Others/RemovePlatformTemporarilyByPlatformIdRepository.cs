using FuDever.Domain.Repositories.Platform.RemovePlatformTemporarilyByPlatformId;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Platform.RemovePlatformTemporarilyByPlatformId.Others;

internal sealed class RemovePlatformTemporarilyByPlatformIdRepository
    : IRemovePlatformTemporarilyByPlatformIdRepository
{
    private readonly RemovePlatformTemporarilyByPlatformIdStateBag _stateBag;
    private IRemovePlatformTemporarilyByPlatformIdCommand _commnad;
    private IRemovePlatformTemporarilyByPlatformIdQuery _query;

    internal RemovePlatformTemporarilyByPlatformIdRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IRemovePlatformTemporarilyByPlatformIdCommand Command
    {
        get
        {
            return _commnad ??= new RemovePlatformTemporarilyByPlatformIdCommand(
                stateBag: _stateBag
            );
        }
    }

    public IRemovePlatformTemporarilyByPlatformIdQuery Query
    {
        get
        {
            return _query ??= new RemovePlatformTemporarilyByPlatformIdQuery(stateBag: _stateBag);
        }
    }
}
