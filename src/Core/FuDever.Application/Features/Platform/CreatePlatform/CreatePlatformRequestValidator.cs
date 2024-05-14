using FluentValidation;

namespace FuDever.Application.Features.Platform.CreatePlatform;

/// <summary>
///     Create platform request validator.
/// </summary>
public sealed class CreatePlatformRequestValidator : AbstractValidator<CreatePlatformRequest>
{
    public CreatePlatformRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.NewPlatformName)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(maximumLength: Domain.Entities.Platform.Metadata.Name.MaxLength)
            .MaximumLength(maximumLength: Domain.Entities.Platform.Metadata.Name.MinLength);
    }
}
