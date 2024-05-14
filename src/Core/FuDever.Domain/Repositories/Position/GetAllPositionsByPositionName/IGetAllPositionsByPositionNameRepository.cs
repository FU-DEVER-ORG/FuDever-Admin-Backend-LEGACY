namespace FuDever.Domain.Repositories.Position.GetAllPositionsByPositionName;

public interface IGetAllPositionsByPositionNameRepository
{
    IGetAllPositionsByPositionNameCommand Command { get; }

    IGetAllPositionsByPositionNameQuery Query { get; }
}
