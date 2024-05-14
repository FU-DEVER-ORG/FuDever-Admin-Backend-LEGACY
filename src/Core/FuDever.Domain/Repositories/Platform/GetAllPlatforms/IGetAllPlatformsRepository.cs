namespace FuDever.Domain.Repositories.Platform.GetAllPlatforms;

public interface IGetAllPlatformsRepository
{
    IGetAllPlatformsCommand Command { get; }

    IGetAllPlatformsQuery Query { get; }
}
