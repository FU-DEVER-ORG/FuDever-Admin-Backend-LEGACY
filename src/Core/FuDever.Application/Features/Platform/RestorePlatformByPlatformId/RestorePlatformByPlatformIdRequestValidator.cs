using FluentValidation;

namespace FuDever.Application.Features.Platform.RestorePlatformByPlatformId;

/// <summary>
///     Restore platform by platform id request validator.
/// </summary>
public sealed class RestorePlatformByPlatformIdRequestValidator
    : AbstractValidator<RestorePlatformByPlatformIdRequest>
{
    public RestorePlatformByPlatformIdRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.PlatformId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();
    }
}
