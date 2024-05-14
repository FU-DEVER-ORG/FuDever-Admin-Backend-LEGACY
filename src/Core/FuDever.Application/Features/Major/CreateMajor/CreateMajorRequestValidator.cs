using FluentValidation;

namespace FuDever.Application.Features.Major.CreateMajor;

/// <summary>
///     Create major request validator.
/// </summary>
public sealed class CreateMajorRequestValidator : AbstractValidator<CreateMajorRequest>
{
    public CreateMajorRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.NewMajorName)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .MinimumLength(minimumLength: Domain.Entities.Major.Metadata.Name.MinLength)
            .MaximumLength(maximumLength: Domain.Entities.Major.Metadata.Name.MaxLength);
    }
}
