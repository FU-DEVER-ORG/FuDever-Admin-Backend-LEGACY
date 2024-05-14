namespace FuDever.Domain.Repositories.Platform.RemovePlatformTemporarilyByPlatformId;

public interface IRemovePlatformTemporarilyByPlatformIdRepository
{
    IRemovePlatformTemporarilyByPlatformIdCommand Command { get; }

    IRemovePlatformTemporarilyByPlatformIdQuery Query { get; }
}
