using FluentValidation;

namespace FuDever.Application.Features.Skill.UpdateSkillBySkillId;

/// <summary>
///     Update skill by skill id request validator.
/// </summary>
public sealed class UpdateSkillBySkillIdRequestValidator
    : AbstractValidator<UpdateSkillBySkillIdRequest>
{
    public UpdateSkillBySkillIdRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.SkillId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();

        RuleFor(expression: request => request.NewSkillName)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(maximumLength: Domain.Entities.Skill.Metadata.Name.MaxLength)
            .MinimumLength(minimumLength: Domain.Entities.Skill.Metadata.Name.MinLength);
    }
}
