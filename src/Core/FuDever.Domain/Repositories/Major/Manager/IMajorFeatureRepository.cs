using FuDever.Domain.Repositories.Major.CreateMajor;
using FuDever.Domain.Repositories.Major.GetAllMajors;
using FuDever.Domain.Repositories.Major.GetAllMajorsByMajorName;
using FuDever.Domain.Repositories.Major.GetAllTemporarilyRemovedMajors;
using FuDever.Domain.Repositories.Major.RemoveMajorPermanentlyByMajorId;
using FuDever.Domain.Repositories.Major.RemoveMajorTemporarilyByMajorId;
using FuDever.Domain.Repositories.Major.RestoreMajorByMajorId;
using FuDever.Domain.Repositories.Major.UpdateMajorByMajorId;

namespace FuDever.Domain.Repositories.Major.Manager;

public interface IMajorFeatureRepository
{
    ICreateMajorRepository CreateMajor { get; }

    IGetAllMajorsRepository GetAllMajors { get; }

    IGetAllMajorsByMajorNameRepository GetAllMajorsByMajorName { get; }

    IGetAllTemporarilyRemovedMajorsRepository GetAllTemporarilyRemovedMajors { get; }

    IRemoveMajorPermanentlyByMajorIdRepository RemoveMajorPermanentlyByMajorId { get; }

    IRemoveMajorTemporarilyByMajorIdRepository RemoveMajorTemporarilyByMajorId { get; }

    IRestoreMajorByMajorIdRepository RestoreMajorByMajorId { get; }

    IUpdateMajorByMajorIdRepository UpdateMajorByMajorId { get; }
}
