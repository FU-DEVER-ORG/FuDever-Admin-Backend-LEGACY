using FuDever.Domain.Repositories.Position.RemovePositionTemporarilyByPositionId;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Position.RemovePositionTemporarilyByPositionId.Others;

internal sealed class RemovePositionTemporarilyByPositionIdRepository
    : IRemovePositionTemporarilyByPositionIdRepository
{
    private readonly RemovePositionTemporarilyByPositionIdStateBag _stateBag;
    private IRemovePositionTemporarilyByPositionIdCommand _commnad;
    private IRemovePositionTemporarilyByPositionIdQuery _query;

    internal RemovePositionTemporarilyByPositionIdRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IRemovePositionTemporarilyByPositionIdCommand Command
    {
        get
        {
            return _commnad ??= new RemovePositionTemporarilyByPositionIdCommand(
                stateBag: _stateBag
            );
        }
    }

    public IRemovePositionTemporarilyByPositionIdQuery Query
    {
        get
        {
            return _query ??= new RemovePositionTemporarilyByPositionIdQuery(stateBag: _stateBag);
        }
    }
}
