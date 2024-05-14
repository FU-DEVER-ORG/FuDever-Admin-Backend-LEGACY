using FluentValidation;

namespace FuDever.Application.Features.Hobby.RemoveHobbyPermanentlyByHobbyId;

/// <summary>
///     Remove hobby permanently by hobby id request validator.
/// </summary>
public sealed class RemoveHobbyPermanentlyByHobbyIdRequestValidator
    : AbstractValidator<RemoveHobbyPermanentlyByHobbyIdRequest>
{
    public RemoveHobbyPermanentlyByHobbyIdRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.HobbyId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();
    }
}
