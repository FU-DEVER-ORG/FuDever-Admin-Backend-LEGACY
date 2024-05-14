namespace FuDever.Application.Features.Department.RemoveDepartmentTemporarilyByDepartmentId;

/// <summary>
///     Extension method for remove department temporarily
///     by department id feature.
/// </summary>
public static class RemoveDepartmentTemporarilyByDepartmentIdExtensionMethods
{
    /// <summary>
    ///     Mapping from feature response status code to
    ///     app code.
    /// </summary>
    /// <param name="statusCode">
    ///     Feature response status code
    /// </param>
    /// <returns>
    ///     New app code.
    /// </returns>
    public static string ToAppCode(
        this RemoveDepartmentTemporarilyByDepartmentIdResponseStatusCode statusCode
    )
    {
        return $"{nameof(Department)}.{nameof(RemoveDepartmentTemporarilyByDepartmentId)}.{(int)statusCode}";
    }
}
