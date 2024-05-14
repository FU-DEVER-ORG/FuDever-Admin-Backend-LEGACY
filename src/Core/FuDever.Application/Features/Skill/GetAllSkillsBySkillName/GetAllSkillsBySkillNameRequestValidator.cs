using FluentValidation;

namespace FuDever.Application.Features.Skill.GetAllSkillsBySkillName;

/// <summary>
///     Get all skills by name request validator.
/// </summary>
public sealed class GetAllSkillsBySkillNameRequestValidator
    : AbstractValidator<GetAllSkillsBySkillNameRequest>
{
    public GetAllSkillsBySkillNameRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.SkillName)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(maximumLength: Domain.Entities.Skill.Metadata.Name.MaxLength)
            .MinimumLength(minimumLength: Domain.Entities.Skill.Metadata.Name.MinLength);

        RuleFor(expression: request => request.CacheExpiredTime)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .Must(predicate: cacheExpiredTime => cacheExpiredTime >= default(int));
    }
}
