using FluentValidation;

namespace FuDever.Application.Features.Admin.ApproveNewUser;

/// <summary>
///     Approve new user request validator.
/// </summary>
public sealed class ApproveNewUserRequestValidator : AbstractValidator<ApproveNewUserRequest>
{
    public ApproveNewUserRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.UserId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();
    }
}
