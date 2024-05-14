using FuDever.Domain.Repositories.Hobby.CreateHobby;
using FuDever.Domain.Repositories.Hobby.GetAllHobbies;
using FuDever.Domain.Repositories.Hobby.GetAllHobbiesByHobbyName;
using FuDever.Domain.Repositories.Hobby.GetAllTemporarilyRemovedHobbies;
using FuDever.Domain.Repositories.Hobby.RemoveHobbyPermanentlyByHobbyId;
using FuDever.Domain.Repositories.Hobby.RemoveHobbyTemporarilyByHobbyId;
using FuDever.Domain.Repositories.Hobby.RestoreHobbyByHobbyId;
using FuDever.Domain.Repositories.Hobby.UpdateHobbyByHobbyId;

namespace FuDever.Domain.Repositories.Hobby.Manager;

/// <summary>
///     Interface for hobby feature repository.
/// </summary>
public interface IHobbyFeatureRepository
{
    ICreateHobbyRepository CreateHobby { get; }

    IGetAllHobbiesRepository GetAllHobbies { get; }

    IGetAllHobbiesByHobbyNameRepository GetAllHobbiesByHobbyName { get; }

    IGetAllTemporarilyRemovedHobbiesRepository GetAllTemporarilyRemovedHobbies { get; }

    IRemoveHobbyPermanentlyByHobbyIdRepository RemoveHobbyPermanentlyByHobbyId { get; }

    IRemoveHobbyTemporarilyByHobbyIdRepository RemoveHobbyTemporarilyByHobbyId { get; }

    IRestoreHobbyByHobbyIdRepository RestoreHobbyByHobbyId { get; }

    IUpdateHobbyByHobbyIdRepository UpdateHobbyByHobbyId { get; }
}
