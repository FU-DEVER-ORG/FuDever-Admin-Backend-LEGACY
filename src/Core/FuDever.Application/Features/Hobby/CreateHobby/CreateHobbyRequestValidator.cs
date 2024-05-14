using FluentValidation;

namespace FuDever.Application.Features.Hobby.CreateHobby;

/// <summary>
///     Validator for create hobby request.
/// </summary>
public sealed class CreateHobbyRequestValidator : AbstractValidator<CreateHobbyRequest>
{
    public CreateHobbyRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.NewHobbyName)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .MinimumLength(minimumLength: Domain.Entities.Hobby.Metadata.Name.MinLength)
            .MaximumLength(maximumLength: Domain.Entities.Hobby.Metadata.Name.MaxLength);
    }
}
