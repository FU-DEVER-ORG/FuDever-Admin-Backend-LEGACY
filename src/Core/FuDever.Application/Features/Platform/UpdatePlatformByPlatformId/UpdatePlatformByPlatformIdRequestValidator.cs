using FluentValidation;

namespace FuDever.Application.Features.Platform.UpdatePlatformByPlatformId;

/// <summary>
///     Update platform by platform id request validator.
/// </summary>
public sealed class UpdatePlatformByPlatformIdRequestValidator
    : AbstractValidator<UpdatePlatformByPlatformIdRequest>
{
    public UpdatePlatformByPlatformIdRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.PlatformId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();

        RuleFor(expression: request => request.NewPlatformName)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(maximumLength: Domain.Entities.Platform.Metadata.Name.MaxLength)
            .MaximumLength(maximumLength: Domain.Entities.Platform.Metadata.Name.MinLength);
    }
}
