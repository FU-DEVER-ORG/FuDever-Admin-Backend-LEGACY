using FluentValidation;

namespace FuDever.Application.Features.Hobby.GetAllHobbiesByHobbyName;

/// <summary>
///     Request validator for getting all hobbies by hobby name.
/// </summary>
public sealed class GetAllHobbiesByHobbyNameRequestValidator
    : AbstractValidator<GetAllHobbiesByHobbyNameRequest>
{
    public GetAllHobbiesByHobbyNameRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.HobbyName)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .MinimumLength(minimumLength: Domain.Entities.Hobby.Metadata.Name.MinLength)
            .MaximumLength(maximumLength: Domain.Entities.Hobby.Metadata.Name.MaxLength);

        RuleFor(expression: request => request.CacheExpiredTime)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .Must(predicate: cacheExpiredTime => cacheExpiredTime >= default(int));
    }
}
