namespace FuDever.Domain.Repositories.Major.GetAllMajors;

public interface IGetAllMajorsRepository
{
    IGetAllMajorsQuery Query { get; }

    IGetAllMajorsCommand Command { get; }
}
