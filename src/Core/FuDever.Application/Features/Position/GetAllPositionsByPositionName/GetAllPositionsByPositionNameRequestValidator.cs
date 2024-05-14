using FluentValidation;

namespace FuDever.Application.Features.Position.GetAllPositionsByPositionName;

/// <summary>
///     Get all position by position name request validator.
/// </summary>
public sealed class GetAllPositionsByPositionNameRequestValidator
    : AbstractValidator<GetAllPositionsByPositionNameRequest>
{
    public GetAllPositionsByPositionNameRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.PositionName)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(maximumLength: Domain.Entities.Position.Metadata.Name.MaxLength)
            .MinimumLength(minimumLength: Domain.Entities.Position.Metadata.Name.MinLength);

        RuleFor(expression: request => request.CacheExpiredTime)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .Must(predicate: cacheExpiredTime => cacheExpiredTime >= default(int));
    }
}
