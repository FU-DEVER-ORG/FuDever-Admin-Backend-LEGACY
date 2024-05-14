namespace FuDever.Domain.Repositories.Hobby.GetAllHobbies;

/// <summary>
///     Repository interface for get all hobbies feature.
/// </summary>
public interface IGetAllHobbiesRepository
{
    IGetAllHobbiesQuery Query { get; }

    IGetAllHobbiesCommand Command { get; }
}
