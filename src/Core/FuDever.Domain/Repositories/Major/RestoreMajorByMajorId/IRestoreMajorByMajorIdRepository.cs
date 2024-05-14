namespace FuDever.Domain.Repositories.Major.RestoreMajorByMajorId;

public interface IRestoreMajorByMajorIdRepository
{
    IRestoreMajorByMajorIdQuery Query { get; }

    IRestoreMajorByMajorIdCommand Command { get; }
}
