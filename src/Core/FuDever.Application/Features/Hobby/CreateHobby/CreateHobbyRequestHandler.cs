using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Data;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Hobby.CreateHobby;

/// <summary>
///     Request handler for create hobby.
/// </summary>
internal sealed class CreateHobbyRequestHandler
    : IRequestHandler<CreateHobbyRequest, CreateHobbyResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDbMinTimeHandler _dbMinTimeHandler;

    public CreateHobbyRequestHandler(IUnitOfWork unitOfWork, IDbMinTimeHandler dbMinTimeHandler)
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
    public async Task<CreateHobbyResponse> Handle(
        CreateHobbyRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is hobby with the same hobby name found.
        var isHobbyFound =
            await _unitOfWork.HobbyFeature.CreateHobby.Query.IsHobbyWithTheSameNameFoundByHobbyNameQueryAsync(
                newHobbyName: request.NewHobbyName,
                cancellationToken: cancellationToken
            );

        // Hobbies with the same hobby name is found.
        if (isHobbyFound)
        {
            // Is hobby temporarily removed by hobby name.
            var isHobbyTemporarilyRemoved =
                await _unitOfWork.HobbyFeature.CreateHobby.Query.IsHobbyTemporarilyRemovedByHobbyNameQueryAsync(
                    newHobbyName: request.NewHobbyName,
                    cancellationToken: cancellationToken
                );

            // Hobby with hobby name is already temporarily removed.
            if (isHobbyTemporarilyRemoved)
            {
                return new()
                {
                    StatusCode = CreateHobbyResponseStatusCode.HOBBY_IS_ALREADY_TEMPORARILY_REMOVED
                };
            }

            return new() { StatusCode = CreateHobbyResponseStatusCode.HOBBY_ALREADY_EXISTS };
        }

        // Create hobby with new hobby name.
        var result = await _unitOfWork.HobbyFeature.CreateHobby.Command.CreateHobbyCommandAsync(
            newHobby: InitNewHobby(newHobbyName: request.NewHobbyName),
            cancellationToken: cancellationToken
        );

        // Database transaction false.
        if (!result)
        {
            return new() { StatusCode = CreateHobbyResponseStatusCode.DATABASE_OPERATION_FAIL };
        }

        return new() { StatusCode = CreateHobbyResponseStatusCode.OPERATION_SUCCESS };
    }

    #region Others
    private Domain.Entities.Hobby InitNewHobby(string newHobbyName)
    {
        return new()
        {
            Id = Guid.NewGuid(),
            Name = newHobbyName,
            RemovedAt = _dbMinTimeHandler.Get(),
            RemovedBy = Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
        };
    }
    #endregion
}
