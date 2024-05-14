namespace FuDever.Domain.Repositories.Hobby.UpdateHobbyByHobbyId;

/// <summary>
///     Repository for updating hobby by hobby id feature.
/// </summary>
public interface IUpdateHobbyByHobbyIdRepository
{
    IUpdateHobbyByHobbyIdQuery Query { get; }

    IUpdateHobbyByHobbyIdCommand Command { get; }
}
