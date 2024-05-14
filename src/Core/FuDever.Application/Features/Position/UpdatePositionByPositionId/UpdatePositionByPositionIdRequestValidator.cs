using FluentValidation;

namespace FuDever.Application.Features.Position.UpdatePositionByPositionId;

/// <summary>
///     Update position by position id request validator.
/// </summary>
public sealed class UpdatePositionByPositionIdRequestValidator
    : AbstractValidator<UpdatePositionByPositionIdRequest>
{
    public UpdatePositionByPositionIdRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.PositionId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();

        RuleFor(expression: request => request.NewPositionName)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(maximumLength: Domain.Entities.Position.Metadata.Name.MaxLength)
            .MinimumLength(minimumLength: Domain.Entities.Position.Metadata.Name.MinLength);
    }
}
