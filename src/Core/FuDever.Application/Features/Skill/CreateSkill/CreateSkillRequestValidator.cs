using FluentValidation;

namespace FuDever.Application.Features.Skill.CreateSkill;

/// <summary>
///     Create skill request validator.
/// </summary>
public sealed class CreateSkillRequestValidator : AbstractValidator<CreateSkillRequest>
{
    public CreateSkillRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.NewSkillName)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(maximumLength: Domain.Entities.Skill.Metadata.Name.MaxLength)
            .MinimumLength(minimumLength: Domain.Entities.Skill.Metadata.Name.MinLength);
    }
}
