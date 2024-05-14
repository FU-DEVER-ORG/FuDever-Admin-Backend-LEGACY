namespace FuDever.Domain.Repositories.Major.CreateMajor;

public interface ICreateMajorRepository
{
    ICreateMajorCommand Command { get; }

    ICreateMajorQuery Query { get; }
}
