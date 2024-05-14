namespace FuDever.Application.Features.Auth.ConfirmUserRegistrationConfirmedEmail;

/// <summary>
///     Confirm user registration confirmed email response status code.
/// </summary>
public enum ConfirmUserRegistrationConfirmedEmailResponseStatusCode
{
    INPUT_VALIDATION_FAIL,
    OPERATION_SUCCESS,
    DATABASE_OPERATION_FAIL,
    TOKEN_IS_NOT_IN_CORRECT_FORMAT,
    USER_IS_NOT_FOUND,
    USER_HAS_CONFIRMED_REGISTRATION_EMAIL,
    USER_IS_TEMPORARILY_REMOVED
}
