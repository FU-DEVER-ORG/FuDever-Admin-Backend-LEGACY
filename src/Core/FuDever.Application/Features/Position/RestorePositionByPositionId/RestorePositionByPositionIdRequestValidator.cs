using FluentValidation;

namespace FuDever.Application.Features.Position.RestorePositionByPositionId;

/// <summary>
///     Restore position by position id request validator.
/// </summary>
public sealed class RestorePositionByPositionIdRequestValidator
    : AbstractValidator<RestorePositionByPositionIdRequest>
{
    public RestorePositionByPositionIdRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.PositionId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();
    }
}
