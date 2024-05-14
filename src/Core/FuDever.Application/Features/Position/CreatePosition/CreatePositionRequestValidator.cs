using FluentValidation;

namespace FuDever.Application.Features.Position.CreatePosition;

/// <summary>
///     Create position request validator.
/// </summary>
public sealed class CreatePositionRequestValidator : AbstractValidator<CreatePositionRequest>
{
    public CreatePositionRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.NewPositionName)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(maximumLength: Domain.Entities.Position.Metadata.Name.MaxLength)
            .MinimumLength(minimumLength: Domain.Entities.Position.Metadata.Name.MinLength);
    }
}
