using FuDever.Domain.Repositories.Platform.RemovePlatformPermanentlyByPlatformId;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Platform.RemovePlatformPermanentlyByPlatformId.Others;

internal sealed class RemovePlatformPermanentlyByPlatformIdRepository
    : IRemovePlatformPermanentlyByPlatformIdRepository
{
    private readonly RemovePlatformPermanentlyByPlatformIdStateBag _stateBag;
    private IRemovePlatformPermanentlyByPlatformIdCommand _commnad;
    private IRemovePlatformPermanentlyByPlatformIdQuery _query;

    internal RemovePlatformPermanentlyByPlatformIdRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IRemovePlatformPermanentlyByPlatformIdCommand Command
    {
        get
        {
            return _commnad ??= new RemovePlatformPermanentlyByPlatformIdCommand(
                stateBag: _stateBag
            );
        }
    }

    public IRemovePlatformPermanentlyByPlatformIdQuery Query
    {
        get
        {
            return _query ??= new RemovePlatformPermanentlyByPlatformIdQuery(stateBag: _stateBag);
        }
    }
}
