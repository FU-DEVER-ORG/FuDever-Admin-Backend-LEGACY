namespace FuDever.Domain.Repositories.Position.GetAllPositions;

public interface IGetAllPositionsRepository
{
    IGetAllPositionsCommand Command { get; }

    IGetAllPositionsQuery Query { get; }
}
