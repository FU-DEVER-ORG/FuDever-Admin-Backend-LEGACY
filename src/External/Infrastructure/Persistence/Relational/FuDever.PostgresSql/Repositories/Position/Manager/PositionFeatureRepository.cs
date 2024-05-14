using FuDever.Domain.Repositories.Position.CreatePosition;
using FuDever.Domain.Repositories.Position.GetAllPositions;
using FuDever.Domain.Repositories.Position.GetAllPositionsByPositionName;
using FuDever.Domain.Repositories.Position.GetAllTemporarilyRemovedPositions;
using FuDever.Domain.Repositories.Position.Manager;
using FuDever.Domain.Repositories.Position.RemovePositionPermanentlyByPositionId;
using FuDever.Domain.Repositories.Position.RemovePositionTemporarilyByPositionId;
using FuDever.Domain.Repositories.Position.RestorePositionByPositionId;
using FuDever.Domain.Repositories.Position.UpdatePositionByPositionId;
using FuDever.PostgresSql.Data;
using FuDever.PostgresSql.Repositories.Position.CreatePosition.Others;
using FuDever.PostgresSql.Repositories.Position.GetAllPositions.Others;
using FuDever.PostgresSql.Repositories.Position.GetAllPositionsByPositionName.Others;
using FuDever.PostgresSql.Repositories.Position.GetAllTemporarilyRemovedPositions.Others;
using FuDever.PostgresSql.Repositories.Position.RemovePositionPermanentlyByPositionId.Others;
using FuDever.PostgresSql.Repositories.Position.RemovePositionTemporarilyByPositionId.Others;
using FuDever.PostgresSql.Repositories.Position.RestorePositionByPositionId.Others;
using FuDever.PostgresSql.Repositories.Position.UpdatePositionByPositionId.Others;

namespace FuDever.PostgresSql.Repositories.Position.Manager;

internal sealed class PositionFeatureRepository : IPositionFeatureRepository
{
    private readonly FuDeverContext _context;
    private ICreatePositionRepository _createPositionRepository;
    private IGetAllPositionsRepository _getAllPositionsRepository;
    private IGetAllPositionsByPositionNameRepository _getAllPositionsByPositionNameRepository;
    private IGetAllTemporarilyRemovedPositionsRepository _getAllTemporarilyRemovedPositionsRepository;
    private IRemovePositionPermanentlyByPositionIdRepository _removePositionPermanentlyByPositionIdRepository;
    private IRemovePositionTemporarilyByPositionIdRepository _removePositionTemporarilyByPositionIdRepository;
    private IRestorePositionByPositionIdRepository _restorePositionByPositionIdRepository;
    private IUpdatePositionByPositionIdRepository _updatePositionByPositionIdRepository;

    internal PositionFeatureRepository(FuDeverContext context)
    {
        _context = context;
    }

    public ICreatePositionRepository CreatePosition
    {
        get
        {
            return _createPositionRepository ??= new CreatePositionRepository(context: _context);
        }
    }

    public IGetAllPositionsRepository GetAllPositions
    {
        get
        {
            return _getAllPositionsRepository ??= new GetAllPositionsRepository(context: _context);
        }
    }

    public IGetAllPositionsByPositionNameRepository GetAllPositionsByPositionName
    {
        get
        {
            return _getAllPositionsByPositionNameRepository ??=
                new GetAllPositionsByPositionNameRepository(context: _context);
        }
    }

    public IGetAllTemporarilyRemovedPositionsRepository GetAllTemporarilyRemovedPositions
    {
        get
        {
            return _getAllTemporarilyRemovedPositionsRepository ??=
                new GetAllTemporarilyRemovedPositionsRepository(context: _context);
        }
    }

    public IRemovePositionPermanentlyByPositionIdRepository RemovePositionPermanentlyByPositionId
    {
        get
        {
            return _removePositionPermanentlyByPositionIdRepository ??=
                new RemovePositionPermanentlyByPositionIdRepository(context: _context);
        }
    }

    public IRemovePositionTemporarilyByPositionIdRepository removePositionTemporarilyByPositionId
    {
        get
        {
            return _removePositionTemporarilyByPositionIdRepository ??=
                new RemovePositionTemporarilyByPositionIdRepository(context: _context);
        }
    }

    public IRestorePositionByPositionIdRepository RestorePositionByPositionId
    {
        get
        {
            return _restorePositionByPositionIdRepository ??=
                new RestorePositionByPositionIdRepository(context: _context);
        }
    }

    public IUpdatePositionByPositionIdRepository UpdatePositionByPositionId
    {
        get
        {
            return _updatePositionByPositionIdRepository ??=
                new UpdatePositionByPositionIdRepository(context: _context);
        }
    }
}
