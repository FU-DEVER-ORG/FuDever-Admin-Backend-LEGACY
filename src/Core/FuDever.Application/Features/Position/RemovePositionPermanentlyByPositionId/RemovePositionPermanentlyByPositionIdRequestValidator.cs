using FluentValidation;

namespace FuDever.Application.Features.Position.RemovePositionPermanentlyByPositionId;

/// <summary>
///     Remove position permanently by position id request validator.
/// </summary>
public sealed class RemovePositionPermanentlyByPositionIdRequestValidator
    : AbstractValidator<RemovePositionPermanentlyByPositionIdRequest>
{
    public RemovePositionPermanentlyByPositionIdRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.PositionId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();
    }
}
