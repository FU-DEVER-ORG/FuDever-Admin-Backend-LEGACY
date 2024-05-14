using FluentValidation;

namespace FuDever.Application.Features.Admin.RejectNewUser;

/// <summary>
///     Validator for reject new user request.
/// </summary>
public sealed class RejectNewUserRequestValidator : AbstractValidator<RejectNewUserRequest>
{
    public RejectNewUserRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.UserId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();
    }
}
