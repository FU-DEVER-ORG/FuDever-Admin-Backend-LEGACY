namespace FuDever.Domain.Repositories.Position.RemovePositionTemporarilyByPositionId;

public interface IRemovePositionTemporarilyByPositionIdRepository
{
    IRemovePositionTemporarilyByPositionIdCommand Command { get; }

    IRemovePositionTemporarilyByPositionIdQuery Query { get; }
}
