namespace FuDever.Domain.Repositories.Major.GetAllTemporarilyRemovedMajors;

public interface IGetAllTemporarilyRemovedMajorsRepository
{
    IGetAllTemporarilyRemovedMajorsQuery Query { get; }

    IGetAllTemporarilyRemovedMajorsCommand Command { get; }
}
