namespace FuDever.Domain.Repositories.Hobby.CreateHobby;

/// <summary>
///     Repository interface for create hobby feature.
/// </summary>
public interface ICreateHobbyRepository
{
    ICreateHobbyQuery Query { get; }

    ICreateHobbyCommand Command { get; }
}
