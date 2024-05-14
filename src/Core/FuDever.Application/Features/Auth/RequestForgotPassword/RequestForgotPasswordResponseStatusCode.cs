namespace FuDever.Application.Features.Auth.RequestForgotPassword;

/// <summary>
///     Request Forgot Password response status code.
/// </summary>
public enum RequestForgotPasswordResponseStatusCode
{
    USER_IS_NOT_FOUND,
    INPUT_VALIDATION_FAIL,
    OPERATION_SUCCESS,
    DATABASE_OPERATION_FAIL,
    SENDING_USER_RESET_PASSWORD_MAIL_FAIL,
    USER_IS_TEMPORARILY_REMOVED
}
