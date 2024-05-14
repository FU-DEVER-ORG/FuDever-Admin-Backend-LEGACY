using FluentValidation;

namespace FuDever.Application.Features.Hobby.RemoveHobbyTemporarilyByHobbyId;

/// <summary>
///     Remove hobby temporarily by hobby id request validator.
/// </summary>
public sealed class RemoveHobbyTemporarilyByHobbyIdRequestValidator
    : AbstractValidator<RemoveHobbyTemporarilyByHobbyIdRequest>
{
    public RemoveHobbyTemporarilyByHobbyIdRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.HobbyId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();
    }
}
