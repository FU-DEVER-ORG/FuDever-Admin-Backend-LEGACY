namespace FuDever.Application.Features.Role.RemoveRoleTemporarilyByRoleId;

/// <summary>
///     Remove role temporarily by role id response status code.
/// </summary>
public enum RemoveRoleTemporarilyByRoleIdResponseStatusCode
{
    INPUT_VALIDATION_FAIL,
    OPERATION_SUCCESS,
    DATABASE_OPERATION_FAIL,
    ROLE_IS_ALREADY_TEMPORARILY_REMOVED,
    ROLE_IS_NOT_FOUND,
    FORBIDDEN,
    UN_AUTHORIZED
}
