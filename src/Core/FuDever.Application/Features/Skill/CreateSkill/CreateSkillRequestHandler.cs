using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Data;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Skill.CreateSkill;

/// <summary>
///     Create skill request handler.
/// </summary>
internal sealed class CreateSkillRequestHandler
    : IRequestHandler<CreateSkillRequest, CreateSkillResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDbMinTimeHandler _dbMinTimeHandler;

    public CreateSkillRequestHandler(IUnitOfWork unitOfWork, IDbMinTimeHandler dbMinTimeHandler)
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
    public async Task<CreateSkillResponse> Handle(
        CreateSkillRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is skill with the same skill name found.
        var isSKillFound =
            await _unitOfWork.SkillFeature.CreateSkill.Query.IsSkillWithTheSameNameFoundBySkillNameQueryAsync(
                newSkillName: request.NewSkillName,
                cancellationToken: cancellationToken
            );

        // Skills with the same skill name is found.
        if (isSKillFound)
        {
            // Is skill temporarily removed by skill name.
            var isSkillTemporarilyRemoved =
                await _unitOfWork.SkillFeature.CreateSkill.Query.IsSkillTemporarilyRemovedBySkillNameQueryAsync(
                    newSkillName: request.NewSkillName,
                    cancellationToken: cancellationToken
                );

            // Skill with skill name is already temporarily removed.
            if (isSkillTemporarilyRemoved)
            {
                return new()
                {
                    StatusCode = CreateSkillResponseStatusCode.SKILL_IS_ALREADY_TEMPORARILY_REMOVED
                };
            }

            return new() { StatusCode = CreateSkillResponseStatusCode.SKILL_ALREADY_EXISTS };
        }

        // Create skill with new skill name.
        var result = await _unitOfWork.SkillFeature.CreateSkill.Command.CreateSkillCommandAsync(
            newSkill: InitNewSkill(newSkillName: request.NewSkillName),
            cancellationToken: cancellationToken
        );

        // Database transaction false.
        if (!result)
        {
            return new() { StatusCode = CreateSkillResponseStatusCode.DATABASE_OPERATION_FAIL };
        }

        return new() { StatusCode = CreateSkillResponseStatusCode.OPERATION_SUCCESS };
    }

    #region Others
    private Domain.Entities.Skill InitNewSkill(string newSkillName)
    {
        return new()
        {
            Id = Guid.NewGuid(),
            Name = newSkillName,
            RemovedAt = _dbMinTimeHandler.Get(),
            RemovedBy = Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
        };
    }
    #endregion
}
