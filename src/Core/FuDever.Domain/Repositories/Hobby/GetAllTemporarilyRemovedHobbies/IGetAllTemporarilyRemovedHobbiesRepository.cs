namespace FuDever.Domain.Repositories.Hobby.GetAllTemporarilyRemovedHobbies;

/// <summary>
///     Repository interface for get all temporarily removed hobbies feature.
/// </summary>
public interface IGetAllTemporarilyRemovedHobbiesRepository
{
    IGetAllTemporarilyRemovedHobbiesQuery Query { get; }

    IGetAllTemporarilyRemovedHobbiesCommand Command { get; }
}
