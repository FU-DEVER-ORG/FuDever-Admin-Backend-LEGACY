namespace FuDever.Domain.Repositories.Hobby.GetAllHobbiesByHobbyName;

/// <summary>
///     Repository interface for get all hobbies by hobby name feature.
/// </summary>
public interface IGetAllHobbiesByHobbyNameRepository
{
    IGetAllHobbiesByHobbyNameQuery Query { get; }

    IGetAllHobbiesByHobbyNameCommand Command { get; }
}
