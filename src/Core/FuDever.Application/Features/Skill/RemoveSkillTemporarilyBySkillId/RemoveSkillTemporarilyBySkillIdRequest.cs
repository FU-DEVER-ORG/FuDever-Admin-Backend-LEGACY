using System;
using FuDever.Application.Features.Skill.RemoveSkillTemporarilyBySkillId.Middlewares;
using MediatR;

namespace FuDever.Application.Features.Skill.RemoveSkillTemporarilyBySkillId;

/// <summary>
///     Remove skill temporarily by skill id request.
/// </summary>
public sealed class RemoveSkillTemporarilyBySkillIdRequest
    : IRequest<RemoveSkillTemporarilyBySkillIdResponse>,
        IRemoveSkillTemporarilyBySkillIdMiddleware
{
    public Guid SkillId { get; init; }
}
