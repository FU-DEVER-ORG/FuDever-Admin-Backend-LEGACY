using System;
using FuDever.Application.Features.Skill.UpdateSkillBySkillId.Middlewares;
using MediatR;

namespace FuDever.Application.Features.Skill.UpdateSkillBySkillId;

/// <summary>
///     Update skill by skill id request.
/// </summary>
public sealed class UpdateSkillBySkillIdRequest
    : IRequest<UpdateSkillBySkillIdResponse>,
        IUpdateSkillBySkillIdMiddleware
{
    public Guid SkillId { get; init; }

    public string NewSkillName { get; init; }
}
