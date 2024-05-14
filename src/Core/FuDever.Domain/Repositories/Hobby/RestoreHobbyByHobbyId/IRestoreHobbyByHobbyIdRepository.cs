namespace FuDever.Domain.Repositories.Hobby.RestoreHobbyByHobbyId;

/// <summary>
///     Repository for restore hobby by hobby id feature.
/// </summary>
public interface IRestoreHobbyByHobbyIdRepository
{
    IRestoreHobbyByHobbyIdQuery Query { get; }

    IRestoreHobbyByHobbyIdCommand Command { get; }
}
