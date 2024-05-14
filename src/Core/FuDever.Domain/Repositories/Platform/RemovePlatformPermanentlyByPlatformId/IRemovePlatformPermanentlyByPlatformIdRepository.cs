namespace FuDever.Domain.Repositories.Platform.RemovePlatformPermanentlyByPlatformId;

public interface IRemovePlatformPermanentlyByPlatformIdRepository
{
    IRemovePlatformPermanentlyByPlatformIdCommand Command { get; }

    IRemovePlatformPermanentlyByPlatformIdQuery Query { get; }
}
