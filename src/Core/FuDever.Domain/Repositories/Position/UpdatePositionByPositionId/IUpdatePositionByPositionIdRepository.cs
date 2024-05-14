namespace FuDever.Domain.Repositories.Position.UpdatePositionByPositionId;

public interface IUpdatePositionByPositionIdRepository
{
    IUpdatePositionByPositionIdCommand Command { get; }

    IUpdatePositionByPositionIdQuery Query { get; }
}
