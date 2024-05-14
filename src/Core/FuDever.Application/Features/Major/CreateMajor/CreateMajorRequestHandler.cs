using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Data;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Major.CreateMajor;

/// <summary>
///     Create major request handler.
/// </summary>
internal sealed class CreateMajorRequestHandler
    : IRequestHandler<CreateMajorRequest, CreateMajorResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDbMinTimeHandler _dbMinTimeHandler;

    public CreateMajorRequestHandler(IUnitOfWork unitOfWork, IDbMinTimeHandler dbMinTimeHandler)
    {
        _unitOfWork = unitOfWork;
        _dbMinTimeHandler = dbMinTimeHandler;
    }

    /// <summary>
    ///     Entry of new request handler.
    /// </summary>
    /// <param name="request">
    ///     Request model.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used for notifying system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     A task containing the response.
    /// </returns>
    public async Task<CreateMajorResponse> Handle(
        CreateMajorRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is major with the same major name found.
        var isMajorFound =
            await _unitOfWork.MajorFeature.CreateMajor.Query.IsMajorWithTheSameNameFoundByMajorNameQueryAsync(
                newMajorName: request.NewMajorName,
                cancellationToken: cancellationToken
            );

        // Majors with the same major name is found.
        if (isMajorFound)
        {
            // Is major temporarily removed by major name.
            var isMajorTemporarilyRemoved =
                await _unitOfWork.MajorFeature.CreateMajor.Query.IsMajorTemporarilyRemovedByMajorNameQueryAsync(
                    newMajorName: request.NewMajorName,
                    cancellationToken: cancellationToken
                );

            // Major with major name is already temporarily removed.
            if (isMajorTemporarilyRemoved)
            {
                return new()
                {
                    StatusCode = CreateMajorResponseStatusCode.MAJOR_IS_ALREADY_TEMPORARILY_REMOVED
                };
            }

            return new() { StatusCode = CreateMajorResponseStatusCode.MAJOR_ALREADY_EXISTS };
        }

        // Create major with new major name.
        var result = await _unitOfWork.MajorFeature.CreateMajor.Command.CreateMajorCommandAsync(
            newMajor: InitNewMajor(newMajorName: request.NewMajorName),
            cancellationToken: cancellationToken
        );

        // Database transaction false.
        if (!result)
        {
            return new() { StatusCode = CreateMajorResponseStatusCode.DATABASE_OPERATION_FAIL };
        }

        return new() { StatusCode = CreateMajorResponseStatusCode.OPERATION_SUCCESS };
    }

    #region Others
    private Domain.Entities.Major InitNewMajor(string newMajorName)
    {
        return new()
        {
            Id = Guid.NewGuid(),
            Name = newMajorName,
            RemovedAt = _dbMinTimeHandler.Get(),
            RemovedBy = Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
        };
    }
    #endregion
}
