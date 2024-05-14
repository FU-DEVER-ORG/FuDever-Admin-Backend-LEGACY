namespace FuDever.Domain.Repositories.Platform.CreatePlatform;

public interface ICreatePlatformRepository
{
    ICreatePlatformCommand Command { get; }

    ICreatePlatformQuery Query { get; }
}
