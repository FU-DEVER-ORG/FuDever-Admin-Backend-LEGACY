namespace FuDever.Domain.Repositories.Position.RemovePositionPermanentlyByPositionId;

public interface IRemovePositionPermanentlyByPositionIdRepository
{
    IRemovePositionPermanentlyByPositionIdCommand Command { get; }

    IRemovePositionPermanentlyByPositionIdQuery Query { get; }
}
