using FluentValidation;

namespace FuDever.Application.Features.Position.RemovePositionTemporarilyByPositionId;

/// <summary>
///     Remove position temporarily by position id request validator.
/// </summary>
public sealed class RemovePositionTemporarilyByPositionIdRequestValidator
    : AbstractValidator<RemovePositionTemporarilyByPositionIdRequest>
{
    public RemovePositionTemporarilyByPositionIdRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.PositionId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();
    }
}
