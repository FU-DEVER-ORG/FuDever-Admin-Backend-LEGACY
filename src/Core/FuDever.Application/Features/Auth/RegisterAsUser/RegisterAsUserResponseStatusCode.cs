namespace FuDever.Application.Features.Auth.RegisterAsUser;

/// <summary>
///     Register as user response status code.
/// </summary>
public enum RegisterAsUserResponseStatusCode
{
    USER_IS_EXISTED,

    //USERNAME_IS_NOT_A_REAL_EMAIL,
    USER_PASSWORD_IS_NOT_VALID,
    INPUT_VALIDATION_FAIL,
    OPERATION_SUCCESS,
    DATABASE_OPERATION_FAIL,
    SENDING_USER_CONFIRMATION_MAIL_FAIL
}
