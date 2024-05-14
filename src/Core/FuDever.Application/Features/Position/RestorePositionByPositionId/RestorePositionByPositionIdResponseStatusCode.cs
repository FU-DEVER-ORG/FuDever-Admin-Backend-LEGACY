namespace FuDever.Application.Features.Position.RestorePositionByPositionId;

/// <summary>
///     Restore position by position id response status code.
/// </summary>
public enum RestorePositionByPositionIdResponseStatusCode
{
    INPUT_VALIDATION_FAIL,
    OPERATION_SUCCESS,
    DATABASE_OPERATION_FAIL,
    POSITION_IS_NOT_TEMPORARILY_REMOVED,
    FORBIDDEN,
    UN_AUTHORIZED,
    POSITION_IS_NOT_FOUND
}
