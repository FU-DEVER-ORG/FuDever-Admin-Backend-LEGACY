namespace FuDever.Domain.Repositories.Major.GetAllMajorsByMajorName;

public interface IGetAllMajorsByMajorNameRepository
{
    IGetAllMajorsByMajorNameQuery Query { get; }

    IGetAllMajorsByMajorNameCommand Command { get; }
}
