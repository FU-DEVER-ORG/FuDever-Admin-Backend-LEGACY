using FluentValidation;

namespace FuDever.Application.Features.Major.GetAllMajorsByMajorName;

/// <summary>
///     Get all majors by major name request validator.
/// </summary>
public sealed class GetAllMajorsByMajorNameRequestValidator
    : AbstractValidator<GetAllMajorsByMajorNameRequest>
{
    public GetAllMajorsByMajorNameRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.MajorName)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .MinimumLength(minimumLength: Domain.Entities.Major.Metadata.Name.MinLength)
            .MaximumLength(maximumLength: Domain.Entities.Major.Metadata.Name.MaxLength);

        RuleFor(expression: request => request.CacheExpiredTime)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .Must(predicate: cacheExpiredTime => cacheExpiredTime >= default(int));
    }
}
