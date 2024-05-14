namespace FuDever.Application.Features.Auth.ResendUserRegistrationConfirmedEmail;

/// <summary>
///     Response status codes for resending user registration confirmed email.
/// </summary>
public enum ResendUserRegistrationConfirmedEmailResponseStatusCode
{
    USER_IS_NOT_FOUND,
    USER_HAS_CONFIRMED_EMAIL,
    INPUT_VALIDATION_FAIL,
    OPERATION_SUCCESS,
    SENDING_USER_CONFIRMATION_MAIL_FAIL,
    USER_IS_TEMPORARILY_REMOVED
}
