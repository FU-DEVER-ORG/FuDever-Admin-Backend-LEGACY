using FuDever.Domain.Repositories.Position.CreatePosition;
using FuDever.Domain.Repositories.Position.GetAllPositions;
using FuDever.Domain.Repositories.Position.GetAllPositionsByPositionName;
using FuDever.Domain.Repositories.Position.GetAllTemporarilyRemovedPositions;
using FuDever.Domain.Repositories.Position.RemovePositionPermanentlyByPositionId;
using FuDever.Domain.Repositories.Position.RemovePositionTemporarilyByPositionId;
using FuDever.Domain.Repositories.Position.RestorePositionByPositionId;
using FuDever.Domain.Repositories.Position.UpdatePositionByPositionId;

namespace FuDever.Domain.Repositories.Position.Manager;

public interface IPositionFeatureRepository
{
    ICreatePositionRepository CreatePosition { get; }

    IGetAllPositionsRepository GetAllPositions { get; }

    IGetAllPositionsByPositionNameRepository GetAllPositionsByPositionName { get; }

    IGetAllTemporarilyRemovedPositionsRepository GetAllTemporarilyRemovedPositions { get; }

    IRemovePositionPermanentlyByPositionIdRepository RemovePositionPermanentlyByPositionId { get; }

    IRemovePositionTemporarilyByPositionIdRepository removePositionTemporarilyByPositionId { get; }

    IRestorePositionByPositionIdRepository RestorePositionByPositionId { get; }

    IUpdatePositionByPositionIdRepository UpdatePositionByPositionId { get; }
}
