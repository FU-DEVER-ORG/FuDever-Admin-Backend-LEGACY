namespace FuDever.Application.Features.Auth.Logout;

/// <summary>
///     Logout response status code.
/// </summary>
public enum LogoutResponseStatusCode
{
    OPERATION_SUCCESS,
    DATABASE_OPERATION_FAIL,
    FORBIDDEN,
    UN_AUTHORIZED
}
