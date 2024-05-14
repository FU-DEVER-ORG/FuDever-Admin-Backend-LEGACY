using FluentValidation;

namespace FuDever.Application.Features.Skill.RemoveSkillPermanentlyBySkillId;

/// <summary>
///     Remove skill permanently by skill id request validator.
/// </summary>
public sealed class RemoveSkillPermanentlyBySkillIdRequestValidator
    : AbstractValidator<RemoveSkillPermanentlyBySkillIdRequest>
{
    public RemoveSkillPermanentlyBySkillIdRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.SkillId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();
    }
}
