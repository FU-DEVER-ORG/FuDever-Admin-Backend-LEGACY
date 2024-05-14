using FuDever.Domain.Repositories.Platform.CreatePlatform;
using FuDever.Domain.Repositories.Platform.GetAllPlatforms;
using FuDever.Domain.Repositories.Platform.GetAllPlatformsByPlatformName;
using FuDever.Domain.Repositories.Platform.GetAllTemporarilyRemovedPlatforms;
using FuDever.Domain.Repositories.Platform.Manager;
using FuDever.Domain.Repositories.Platform.RemovePlatformPermanentlyByPlatformId;
using FuDever.Domain.Repositories.Platform.RemovePlatformTemporarilyByPlatformId;
using FuDever.Domain.Repositories.Platform.RestorePlatformByPlatformId;
using FuDever.Domain.Repositories.Platform.UpdatePlatformByPlatformId;
using FuDever.PostgresSql.Data;
using FuDever.PostgresSql.Repositories.Platform.CreatePlatform.Others;
using FuDever.PostgresSql.Repositories.Platform.GetAllPlatforms.Others;
using FuDever.PostgresSql.Repositories.Platform.GetAllPlatformsByPlatformName.Others;
using FuDever.PostgresSql.Repositories.Platform.GetAllTemporarilyRemovedPlatforms.Others;
using FuDever.PostgresSql.Repositories.Platform.RemovePlatformPermanentlyByPlatformId.Others;
using FuDever.PostgresSql.Repositories.Platform.RemovePlatformTemporarilyByPlatformId.Others;
using FuDever.PostgresSql.Repositories.Platform.RestorePlatformByPlatformId.Others;
using FuDever.PostgresSql.Repositories.Platform.UpdatePlatformByPlatformId.Others;

namespace FuDever.PostgresSql.Repositories.Platform.Manager;

internal sealed class PlatformFeatureRepository : IPlatformFeatureRepository
{
    private ICreatePlatformRepository _createPlatformRepository;
    private IGetAllPlatformsRepository _getAllPlatformsRepository;
    private IGetAllPlatformsByPlatformNameRepository _getAllPlatformsByPlatformNameRepository;
    private IGetAllTemporarilyRemovedPlatformsRepository _getAllTemporarilyRemovedPlatformsRepository;
    private IRemovePlatformPermanentlyByPlatformIdRepository _removePlatformPermanentlyByPlatformIdRepository;
    private IRemovePlatformTemporarilyByPlatformIdRepository _removePlatformTemporarilyByPlatformIdRepository;
    private IRestorePlatformByPlatformIdRepository _restorePlatformByPlatformIdRepository;
    private IUpdatePlatformByPlatformIdRepository _updatePlatformByPlatformIdRepository;
    private readonly FuDeverContext _context;

    internal PlatformFeatureRepository(FuDeverContext context)
    {
        _context = context;
    }

    public ICreatePlatformRepository CreatePlatform
    {
        get
        {
            return _createPlatformRepository ??= new CreatePlatformRepository(context: _context);
        }
    }

    public IGetAllPlatformsRepository GetAllPlatforms
    {
        get
        {
            return _getAllPlatformsRepository ??= new GetAllPlatformsRepository(context: _context);
        }
    }

    public IGetAllPlatformsByPlatformNameRepository GetAllPlatformsByPlatformName
    {
        get
        {
            return _getAllPlatformsByPlatformNameRepository ??=
                new GetAllPlatformsByPlatformNameRepository(context: _context);
        }
    }

    public IGetAllTemporarilyRemovedPlatformsRepository GetAllTemporarilyRemovedPlatforms
    {
        get
        {
            return _getAllTemporarilyRemovedPlatformsRepository ??=
                new GetAllTemporarilyRemovedPlatformsRepository(context: _context);
        }
    }

    public IRemovePlatformPermanentlyByPlatformIdRepository RemovePlatformPermanentlyByPlatformId
    {
        get
        {
            return _removePlatformPermanentlyByPlatformIdRepository ??=
                new RemovePlatformPermanentlyByPlatformIdRepository(context: _context);
        }
    }

    public IRemovePlatformTemporarilyByPlatformIdRepository RemovePlatformTemporarilyByPlatformId
    {
        get
        {
            return _removePlatformTemporarilyByPlatformIdRepository ??=
                new RemovePlatformTemporarilyByPlatformIdRepository(context: _context);
        }
    }

    public IRestorePlatformByPlatformIdRepository RestorePlatformByPlatformId
    {
        get
        {
            return _restorePlatformByPlatformIdRepository ??=
                new RestorePlatformByPlatformIdRepository(context: _context);
        }
    }

    public IUpdatePlatformByPlatformIdRepository UpdatePlatformByPlatformId
    {
        get
        {
            return _updatePlatformByPlatformIdRepository ??=
                new UpdatePlatformByPlatformIdRepository(context: _context);
        }
    }
}
