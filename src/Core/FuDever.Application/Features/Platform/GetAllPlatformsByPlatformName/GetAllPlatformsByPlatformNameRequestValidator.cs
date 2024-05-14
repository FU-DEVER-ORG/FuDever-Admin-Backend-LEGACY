using FluentValidation;

namespace FuDever.Application.Features.Platform.GetAllPlatformsByPlatformName;

/// <summary>
///     Get all platforms by name request validator.
/// </summary>
public sealed class GetAllPlatformsByPlatformNameRequestValidator
    : AbstractValidator<GetAllPlatformsByPlatformNameRequest>
{
    public GetAllPlatformsByPlatformNameRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.PlatformName)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(maximumLength: Domain.Entities.Platform.Metadata.Name.MaxLength)
            .MaximumLength(maximumLength: Domain.Entities.Platform.Metadata.Name.MinLength);

        RuleFor(expression: request => request.CacheExpiredTime)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .Must(predicate: cacheExpiredTime => cacheExpiredTime >= default(int));
    }
}
