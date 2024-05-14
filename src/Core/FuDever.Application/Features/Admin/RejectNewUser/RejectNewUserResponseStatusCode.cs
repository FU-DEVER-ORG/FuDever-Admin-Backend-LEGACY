namespace FuDever.Application.Features.Admin.RejectNewUser;

/// <summary>
///     Response status codes of reject new user feature.
/// </summary>
public enum RejectNewUserResponseStatusCode
{
    INPUT_VALIDATION_FAIL,
    OPERATION_SUCCESS,
    DATABASE_OPERATION_FAIL,
    FORBIDDEN,
    UN_AUTHORIZED,
    USER_IS_NOT_FOUND,
    USER_IS_TEMPORARILY_REMOVED,
    USER_IS_ALREADY_REJECTED,
    USER_IS_ALREADY_APPROVED,
    USER_IS_ALREADY_EXPIRED
}
