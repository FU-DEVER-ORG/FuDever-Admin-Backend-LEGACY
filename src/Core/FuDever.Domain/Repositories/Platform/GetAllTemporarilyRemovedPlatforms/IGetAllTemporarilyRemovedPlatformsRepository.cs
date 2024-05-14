namespace FuDever.Domain.Repositories.Platform.GetAllTemporarilyRemovedPlatforms;

public interface IGetAllTemporarilyRemovedPlatformsRepository
{
    IGetAllTemporarilyRemovedPlatformsCommand Command { get; }

    IGetAllTemporarilyRemovedPlatformsQuery Query { get; }
}
