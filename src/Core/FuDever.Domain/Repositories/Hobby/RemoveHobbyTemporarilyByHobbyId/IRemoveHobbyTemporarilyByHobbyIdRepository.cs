namespace FuDever.Domain.Repositories.Hobby.RemoveHobbyTemporarilyByHobbyId;

/// <summary>
///     Repository for remove hobby temporarily by hobby id feature.
/// </summary>
public interface IRemoveHobbyTemporarilyByHobbyIdRepository
{
    IRemoveHobbyTemporarilyByHobbyIdQuery Query { get; }

    IRemoveHobbyTemporarilyByHobbyIdCommand Command { get; }
}
