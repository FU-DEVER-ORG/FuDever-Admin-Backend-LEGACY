namespace FuDever.Domain.Repositories.Hobby.RemoveHobbyPermanentlyByHobbyId;

/// <summary>
///     Repository interface for remove hobby
///     permanently by hobby id feature.
/// </summary>
public interface IRemoveHobbyPermanentlyByHobbyIdRepository
{
    IRemoveHobbyPermanentlyByHobbyIdQuery Query { get; }

    IRemoveHobbyPermanentlyByHobbyIdCommand Command { get; }
}
