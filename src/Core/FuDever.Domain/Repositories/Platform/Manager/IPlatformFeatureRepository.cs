using FuDever.Domain.Repositories.Platform.CreatePlatform;
using FuDever.Domain.Repositories.Platform.GetAllPlatforms;
using FuDever.Domain.Repositories.Platform.GetAllPlatformsByPlatformName;
using FuDever.Domain.Repositories.Platform.GetAllTemporarilyRemovedPlatforms;
using FuDever.Domain.Repositories.Platform.RemovePlatformPermanentlyByPlatformId;
using FuDever.Domain.Repositories.Platform.RemovePlatformTemporarilyByPlatformId;
using FuDever.Domain.Repositories.Platform.RestorePlatformByPlatformId;
using FuDever.Domain.Repositories.Platform.UpdatePlatformByPlatformId;

namespace FuDever.Domain.Repositories.Platform.Manager;

public interface IPlatformFeatureRepository
{
    ICreatePlatformRepository CreatePlatform { get; }

    IGetAllPlatformsRepository GetAllPlatforms { get; }

    IGetAllPlatformsByPlatformNameRepository GetAllPlatformsByPlatformName { get; }

    IGetAllTemporarilyRemovedPlatformsRepository GetAllTemporarilyRemovedPlatforms { get; }

    IRemovePlatformPermanentlyByPlatformIdRepository RemovePlatformPermanentlyByPlatformId { get; }

    IRemovePlatformTemporarilyByPlatformIdRepository RemovePlatformTemporarilyByPlatformId { get; }

    IRestorePlatformByPlatformIdRepository RestorePlatformByPlatformId { get; }

    IUpdatePlatformByPlatformIdRepository UpdatePlatformByPlatformId { get; }
}
