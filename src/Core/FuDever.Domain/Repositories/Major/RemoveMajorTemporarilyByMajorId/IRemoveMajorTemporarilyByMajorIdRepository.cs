namespace FuDever.Domain.Repositories.Major.RemoveMajorTemporarilyByMajorId;

public interface IRemoveMajorTemporarilyByMajorIdRepository
{
    IRemoveMajorTemporarilyByMajorIdCommand Command { get; }

    IRemoveMajorTemporarilyByMajorIdQuery Query { get; }
}
