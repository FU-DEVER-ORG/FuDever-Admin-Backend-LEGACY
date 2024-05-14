using FluentValidation;

namespace FuDever.Application.Features.Hobby.UpdateHobbyByHobbyId;

/// <summary>
///     Update hobby by hobby id request validator.
/// </summary>
public sealed class UpdateHobbyByHobbyIdRequestValidator
    : AbstractValidator<UpdateHobbyByHobbyIdRequest>
{
    public UpdateHobbyByHobbyIdRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.HobbyId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();

        RuleFor(expression: request => request.NewHobbyName)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .MinimumLength(minimumLength: Domain.Entities.Hobby.Metadata.Name.MinLength)
            .MaximumLength(maximumLength: Domain.Entities.Hobby.Metadata.Name.MaxLength);
    }
}
