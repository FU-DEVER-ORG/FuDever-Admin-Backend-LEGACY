namespace FuDever.Domain.Repositories.Position.CreatePosition;

public interface ICreatePositionRepository
{
    ICreatePositionQuery Query { get; }

    ICreatePositionCommand Command { get; }
}
