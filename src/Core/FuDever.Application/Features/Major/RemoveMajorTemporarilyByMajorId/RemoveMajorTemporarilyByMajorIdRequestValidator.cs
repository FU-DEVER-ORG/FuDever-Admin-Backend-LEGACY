using FluentValidation;

namespace FuDever.Application.Features.Major.RemoveMajorTemporarilyByMajorId;

/// <summary>
///     Remove major temporarily by major id request validator.
/// </summary>
public sealed class RemoveMajorTemporarilyByMajorIdRequestValidator
    : AbstractValidator<RemoveMajorTemporarilyByMajorIdRequest>
{
    public RemoveMajorTemporarilyByMajorIdRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.MajorId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();
    }
}
