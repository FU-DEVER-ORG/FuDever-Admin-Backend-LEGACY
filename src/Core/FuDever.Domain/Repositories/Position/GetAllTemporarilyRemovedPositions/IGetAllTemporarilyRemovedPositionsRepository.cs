namespace FuDever.Domain.Repositories.Position.GetAllTemporarilyRemovedPositions;

public interface IGetAllTemporarilyRemovedPositionsRepository
{
    IGetAllTemporarilyRemovedPositionsCommand Command { get; }

    IGetAllTemporarilyRemovedPositionsQuery Query { get; }
}
