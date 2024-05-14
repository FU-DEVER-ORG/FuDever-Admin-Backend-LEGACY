using FuDever.Domain.Repositories.Major.CreateMajor;
using FuDever.Domain.Repositories.Major.GetAllMajors;
using FuDever.Domain.Repositories.Major.GetAllMajorsByMajorName;
using FuDever.Domain.Repositories.Major.GetAllTemporarilyRemovedMajors;
using FuDever.Domain.Repositories.Major.Manager;
using FuDever.Domain.Repositories.Major.RemoveMajorPermanentlyByMajorId;
using FuDever.Domain.Repositories.Major.RemoveMajorTemporarilyByMajorId;
using FuDever.Domain.Repositories.Major.RestoreMajorByMajorId;
using FuDever.Domain.Repositories.Major.UpdateMajorByMajorId;
using FuDever.PostgresSql.Data;
using FuDever.PostgresSql.Repositories.Major.CreateMajor.Others;
using FuDever.PostgresSql.Repositories.Major.GetAllMajors.Others;
using FuDever.PostgresSql.Repositories.Major.GetAllMajorsByMajorName.Others;
using FuDever.PostgresSql.Repositories.Major.GetAllTemporarilyRemovedMajors.Others;
using FuDever.PostgresSql.Repositories.Major.RemoveMajorPermanentlyByMajorId.Others;
using FuDever.PostgresSql.Repositories.Major.RemoveMajorTemporarilyByMajorId.Others;
using FuDever.PostgresSql.Repositories.Major.RestoreMajorByMajorId.Others;
using FuDever.PostgresSql.Repositories.Major.UpdateMajorByMajorId.Others;

namespace FuDever.PostgresSql.Repositories.Major.Manager;

internal sealed class MajorFeatureRepository : IMajorFeatureRepository
{
    private readonly FuDeverContext _context;
    private ICreateMajorRepository _createMajorRepository;
    private IGetAllMajorsRepository _getAllMajorsRepository;
    private IGetAllMajorsByMajorNameRepository _getAllMajorsByMajorNameRepository;
    private IGetAllTemporarilyRemovedMajorsRepository _getAllTemporarilyRemovedMajorsRepository;
    private IRemoveMajorPermanentlyByMajorIdRepository _removeMajorPermanentlyByMajorIdRepository;
    private IRemoveMajorTemporarilyByMajorIdRepository _removeMajorTemporarilyByMajorIdRepository;
    private IRestoreMajorByMajorIdRepository _restoreMajorByMajorIdRepository;
    private IUpdateMajorByMajorIdRepository _updateMajorByMajorIdRepository;

    internal MajorFeatureRepository(FuDeverContext context)
    {
        _context = context;
    }

    public ICreateMajorRepository CreateMajor
    {
        get { return _createMajorRepository ??= new CreateMajorRepository(context: _context); }
    }

    public IGetAllMajorsRepository GetAllMajors
    {
        get { return _getAllMajorsRepository ??= new GetAllMajorsRepository(context: _context); }
    }

    public IGetAllMajorsByMajorNameRepository GetAllMajorsByMajorName
    {
        get
        {
            return _getAllMajorsByMajorNameRepository ??= new GetAllMajorsByMajorNameRepository(
                context: _context
            );
        }
    }

    public IGetAllTemporarilyRemovedMajorsRepository GetAllTemporarilyRemovedMajors
    {
        get
        {
            return _getAllTemporarilyRemovedMajorsRepository ??=
                new GetAllTemporarilyRemovedMajorsRepository(context: _context);
        }
    }

    public IRemoveMajorPermanentlyByMajorIdRepository RemoveMajorPermanentlyByMajorId
    {
        get
        {
            return _removeMajorPermanentlyByMajorIdRepository ??=
                new RemoveMajorPermanentlyByMajorIdRepository(context: _context);
        }
    }

    public IRemoveMajorTemporarilyByMajorIdRepository RemoveMajorTemporarilyByMajorId
    {
        get
        {
            return _removeMajorTemporarilyByMajorIdRepository ??=
                new RemoveMajorTemporarilyByMajorIdRepository(context: _context);
        }
    }

    public IRestoreMajorByMajorIdRepository RestoreMajorByMajorId
    {
        get
        {
            return _restoreMajorByMajorIdRepository ??= new RestoreMajorByMajorIdRepository(
                context: _context
            );
        }
    }

    public IUpdateMajorByMajorIdRepository UpdateMajorByMajorId
    {
        get
        {
            return _updateMajorByMajorIdRepository ??= new UpdateMajorByMajorIdRepository(
                context: _context
            );
        }
    }
}
