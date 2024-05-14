namespace FuDever.Domain.Repositories.Major.RemoveMajorPermanentlyByMajorId;

public interface IRemoveMajorPermanentlyByMajorIdRepository
{
    IRemoveMajorPermanentlyByMajorIdQuery Query { get; }

    IRemoveMajorPermanentlyByMajorIdCommand Command { get; }
}
