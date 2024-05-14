namespace FuDever.Domain.Repositories.Platform.UpdatePlatformByPlatformId;

public interface IUpdatePlatformByPlatformIdRepository
{
    IUpdatePlatformByPlatformIdCommand Command { get; }

    IUpdatePlatformByPlatformIdQuery Query { get; }
}
