using FluentValidation;

namespace FuDever.Application.Features.Platform.RemovePlatformTemporarilyByPlatformId;

/// <summary>
///     Remove platform temporarily by platform id request validator.
/// </summary>
public sealed class RemovePlatformTemporarilyByPlatformIdRequestValidator
    : AbstractValidator<RemovePlatformTemporarilyByPlatformIdRequest>
{
    public RemovePlatformTemporarilyByPlatformIdRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.PlatformId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();
    }
}
