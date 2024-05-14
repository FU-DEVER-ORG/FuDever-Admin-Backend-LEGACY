using FluentValidation;

namespace FuDever.Application.Features.Platform.RemovePlatformPermanentlyByPlatformId;

/// <summary>
///     Validator for remove platform permanently by platform id request.
/// </summary>
public sealed class RemovePlatformPermanentlyByPlatformIdRequestValidator
    : AbstractValidator<RemovePlatformPermanentlyByPlatformIdRequest>
{
    public RemovePlatformPermanentlyByPlatformIdRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.PlatformId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();
    }
}
