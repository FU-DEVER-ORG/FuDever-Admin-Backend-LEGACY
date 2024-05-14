namespace FuDever.Application.Features.Admin.ApproveNewUser;

/// <summary>
///     Response status code for approve new user.
/// </summary>
public enum ApproveNewUserResponseStatusCode
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
