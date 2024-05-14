namespace FuDever.Domain.Repositories.Position.RestorePositionByPositionId;

public interface IRestorePositionByPositionIdRepository
{
    IRestorePositionByPositionIdCommand Command { get; }

    IRestorePositionByPositionIdQuery Query { get; }
}
