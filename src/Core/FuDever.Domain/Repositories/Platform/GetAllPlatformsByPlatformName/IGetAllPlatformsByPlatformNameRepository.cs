namespace FuDever.Domain.Repositories.Platform.GetAllPlatformsByPlatformName;

public interface IGetAllPlatformsByPlatformNameRepository
{
    IGetAllPlatformsByPlatformNameCommand Command { get; }

    IGetAllPlatformsByPlatformNameQuery Query { get; }
}
