using FluentValidation;

namespace FuDever.Application.Features.Major.RemoveMajorPermanentlyByMajorId;

/// <summary>
///     Remove major permanently by major Id request validator.
/// </summary>
public sealed class RemoveMajorPermanentlyByMajorIdRequestValidator
    : AbstractValidator<RemoveMajorPermanentlyByMajorIdRequest>
{
    public RemoveMajorPermanentlyByMajorIdRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.MajorId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();
    }
}
