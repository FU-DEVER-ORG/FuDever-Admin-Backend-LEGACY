namespace FuDever.Application.Features.Major.CreateMajor;

/// <summary>
///     Create major response status code.
/// </summary>
public enum CreateMajorResponseStatusCode
{
    INPUT_VALIDATION_FAIL,
    OPERATION_SUCCESS,
    DATABASE_OPERATION_FAIL,
    MAJOR_IS_ALREADY_TEMPORARILY_REMOVED,
    FORBIDDEN,
    NOT_FOUND,
    MAJOR_ALREADY_EXISTS,
    UN_AUTHORIZED
}
