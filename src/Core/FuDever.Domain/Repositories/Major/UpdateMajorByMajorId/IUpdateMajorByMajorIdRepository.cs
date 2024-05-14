namespace FuDever.Domain.Repositories.Major.UpdateMajorByMajorId;

public interface IUpdateMajorByMajorIdRepository
{
    IUpdateMajorByMajorIdCommand Command { get; }

    IUpdateMajorByMajorIdQuery Query { get; }
}
