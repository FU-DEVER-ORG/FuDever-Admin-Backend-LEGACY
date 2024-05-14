using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Data;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Platform.CreatePlatform;

/// <summary>
///     Create platform request handler.
/// </summary>
internal sealed class CreatePlatformRequestHandler
    : IRequestHandler<CreatePlatformRequest, CreatePlatformResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDbMinTimeHandler _dbMinTimeHandler;

    public CreatePlatformRequestHandler(IUnitOfWork unitOfWork, IDbMinTimeHandler dbMinTimeHandler)
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
    public async Task<CreatePlatformResponse> Handle(
        CreatePlatformRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is platform with the same platform name found.
        var isPlatformFound =
            await _unitOfWork.PlatformFeature.CreatePlatform.Query.IsPlatformWithTheSameNameFoundByPlatformNameQueryAsync(
                newPlatformName: request.NewPlatformName,
                cancellationToken: cancellationToken
            );

        // Platforms with the same platform name is found.
        if (isPlatformFound)
        {
            // Is platform temporarily removed by platform name.
            var isPlatformTemporarilyRemoved =
                await _unitOfWork.PlatformFeature.CreatePlatform.Query.IsPlatformTemporarilyRemovedByPlatformNameQueryAsync(
                    newPlatformName: request.NewPlatformName,
                    cancellationToken: cancellationToken
                );

            // Platform with platform name is already temporarily removed.
            if (isPlatformTemporarilyRemoved)
            {
                return new()
                {
                    StatusCode =
                        CreatePlatformResponseStatusCode.PLATFORM_IS_ALREADY_TEMPORARILY_REMOVED
                };
            }

            return new() { StatusCode = CreatePlatformResponseStatusCode.PLATFORM_ALREADY_EXISTS };
        }

        // Create platform with new platform name.
        var result =
            await _unitOfWork.PlatformFeature.CreatePlatform.Command.CreatePlatformCommandAsync(
                newPlatform: InitNewPlatform(newPlatformName: request.NewPlatformName),
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new() { StatusCode = CreatePlatformResponseStatusCode.DATABASE_OPERATION_FAIL };
        }

        return new() { StatusCode = CreatePlatformResponseStatusCode.OPERATION_SUCCESS };
    }

    #region Others
    private Domain.Entities.Platform InitNewPlatform(string newPlatformName)
    {
        return new()
        {
            Id = Guid.NewGuid(),
            Name = newPlatformName,
            RemovedAt = _dbMinTimeHandler.Get(),
            RemovedBy = Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
        };
    }
    #endregion
}
