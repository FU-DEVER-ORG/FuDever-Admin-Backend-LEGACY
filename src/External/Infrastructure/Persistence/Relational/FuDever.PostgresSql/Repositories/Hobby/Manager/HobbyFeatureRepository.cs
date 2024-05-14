using FuDever.Domain.Repositories.Hobby.CreateHobby;
using FuDever.Domain.Repositories.Hobby.GetAllHobbies;
using FuDever.Domain.Repositories.Hobby.GetAllHobbiesByHobbyName;
using FuDever.Domain.Repositories.Hobby.GetAllTemporarilyRemovedHobbies;
using FuDever.Domain.Repositories.Hobby.Manager;
using FuDever.Domain.Repositories.Hobby.RemoveHobbyPermanentlyByHobbyId;
using FuDever.Domain.Repositories.Hobby.RemoveHobbyTemporarilyByHobbyId;
using FuDever.Domain.Repositories.Hobby.RestoreHobbyByHobbyId;
using FuDever.Domain.Repositories.Hobby.UpdateHobbyByHobbyId;
using FuDever.PostgresSql.Data;
using FuDever.PostgresSql.Repositories.Hobby.CreateHobby.Others;
using FuDever.PostgresSql.Repositories.Hobby.GetAllHobbies.Others;
using FuDever.PostgresSql.Repositories.Hobby.GetAllHobbiesByHobbyName.Others;
using FuDever.PostgresSql.Repositories.Hobby.GetAllTemporarilyRemovedHobbies.Others;
using FuDever.PostgresSql.Repositories.Hobby.RemoveHobbyPermanentlyByHobbyId.Others;
using FuDever.PostgresSql.Repositories.Hobby.RemoveHobbyTemporarilyByHobbyId.Others;
using FuDever.PostgresSql.Repositories.Hobby.RestoreHobbyByHobbyId.Others;
using FuDever.PostgresSql.Repositories.Hobby.UpdateHobbyByHobbyId.Others;

namespace FuDever.PostgresSql.Repositories.Hobby.Manager;

internal sealed class HobbyFeatureRepository : IHobbyFeatureRepository
{
    private readonly FuDeverContext _context;
    private ICreateHobbyRepository _createHobbyRepository;
    private IGetAllHobbiesRepository _getAllHobbiesRepository;
    private IGetAllHobbiesByHobbyNameRepository _getAllHobbiesByHobbyNameRepository;
    private IGetAllTemporarilyRemovedHobbiesRepository _getAllTemporarilyRemovedHobbiesRepository;
    private IRemoveHobbyPermanentlyByHobbyIdRepository _removeHobbyPermanentlyByHobbyIdRepository;
    private IRemoveHobbyTemporarilyByHobbyIdRepository _removeHobbyTemporarilyByHobbyIdRepository;
    private IRestoreHobbyByHobbyIdRepository _restoreHobbyByHobbyIdRepository;
    private IUpdateHobbyByHobbyIdRepository _updateHobbyByHobbyIdRepository;

    internal HobbyFeatureRepository(FuDeverContext context)
    {
        _context = context;
    }

    public ICreateHobbyRepository CreateHobby
    {
        get { return _createHobbyRepository ??= new CreateHobbyRepository(context: _context); }
    }

    public IGetAllHobbiesRepository GetAllHobbies
    {
        get { return _getAllHobbiesRepository ??= new GetAllHobbiesRepository(context: _context); }
    }

    public IGetAllHobbiesByHobbyNameRepository GetAllHobbiesByHobbyName
    {
        get
        {
            return _getAllHobbiesByHobbyNameRepository ??= new GetAllHobbiesByHobbyNameRepository(
                context: _context
            );
        }
    }

    public IGetAllTemporarilyRemovedHobbiesRepository GetAllTemporarilyRemovedHobbies
    {
        get
        {
            return _getAllTemporarilyRemovedHobbiesRepository ??=
                new GetAllTemporarilyRemovedHobbiesRepository(context: _context);
        }
    }

    public IRemoveHobbyPermanentlyByHobbyIdRepository RemoveHobbyPermanentlyByHobbyId
    {
        get
        {
            return _removeHobbyPermanentlyByHobbyIdRepository ??=
                new RemoveHobbyPermanentlyByHobbyIdRepository(context: _context);
        }
    }

    public IRemoveHobbyTemporarilyByHobbyIdRepository RemoveHobbyTemporarilyByHobbyId
    {
        get
        {
            return _removeHobbyTemporarilyByHobbyIdRepository ??=
                new RemoveHobbyTemporarilyByHobbyIdRepository(context: _context);
        }
    }

    public IRestoreHobbyByHobbyIdRepository RestoreHobbyByHobbyId
    {
        get
        {
            return _restoreHobbyByHobbyIdRepository ??= new RestoreHobbyByHobbyIdRepository(
                context: _context
            );
        }
    }

    public IUpdateHobbyByHobbyIdRepository UpdateHobbyByHobbyId
    {
        get
        {
            return _updateHobbyByHobbyIdRepository ??= new UpdateHobbyByHobbyIdRepository(
                context: _context
            );
        }
    }
}
