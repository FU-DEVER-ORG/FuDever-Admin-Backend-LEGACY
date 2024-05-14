using FluentValidation;

namespace FuDever.Application.Features.Major.UpdateMajorByMajorId;

/// <summary>
///     Update major by major id request validator.
/// </summary>
public sealed class UpdateMajorByMajorIdRequestValidator
    : AbstractValidator<UpdateMajorByMajorIdRequest>
{
    public UpdateMajorByMajorIdRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.MajorId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();

        RuleFor(expression: request => request.NewMajorName)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .MinimumLength(minimumLength: Domain.Entities.Major.Metadata.Name.MinLength)
            .MaximumLength(maximumLength: Domain.Entities.Major.Metadata.Name.MaxLength);
    }
}
