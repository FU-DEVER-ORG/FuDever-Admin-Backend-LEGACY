namespace FuDever.Domain.Repositories.Platform.RestorePlatformByPlatformId;

public interface IRestorePlatformByPlatformIdRepository
{
    IRestorePlatformByPlatformIdCommand Command { get; }

    IRestorePlatformByPlatformIdQuery Query { get; }
}
