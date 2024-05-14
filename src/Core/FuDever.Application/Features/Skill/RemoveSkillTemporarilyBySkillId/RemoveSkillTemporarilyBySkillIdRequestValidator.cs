using FluentValidation;

namespace FuDever.Application.Features.Skill.RemoveSkillTemporarilyBySkillId;

/// <summary>
///     Remove skill temporarily by skill id request validator.
/// </summary>
public sealed class RemoveSkillTemporarilyBySkillIdRequestValidator
    : AbstractValidator<RemoveSkillTemporarilyBySkillIdRequest>
{
    public RemoveSkillTemporarilyBySkillIdRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.SkillId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();
    }
}
