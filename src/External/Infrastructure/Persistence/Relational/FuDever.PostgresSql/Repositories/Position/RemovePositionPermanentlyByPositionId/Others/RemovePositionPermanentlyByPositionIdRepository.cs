using FuDever.Domain.Repositories.Position.RemovePositionPermanentlyByPositionId;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Position.RemovePositionPermanentlyByPositionId.Others;

internal sealed class RemovePositionPermanentlyByPositionIdRepository
    : IRemovePositionPermanentlyByPositionIdRepository
{
    private readonly RemovePositionPermanentlyByPositionIdStateBag _stateBag;
    private IRemovePositionPermanentlyByPositionIdCommand _commnad;
    private IRemovePositionPermanentlyByPositionIdQuery _query;

    internal RemovePositionPermanentlyByPositionIdRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IRemovePositionPermanentlyByPositionIdCommand Command
    {
        get
        {
            return _commnad ??= new RemovePositionPermanentlyByPositionIdCommand(
                stateBag: _stateBag
            );
        }
    }

    public IRemovePositionPermanentlyByPositionIdQuery Query
    {
        get
        {
            return _query ??= new RemovePositionPermanentlyByPositionIdQuery(stateBag: _stateBag);
        }
    }
}
