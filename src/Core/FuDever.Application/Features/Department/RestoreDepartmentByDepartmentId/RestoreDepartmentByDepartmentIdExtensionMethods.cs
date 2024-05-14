namespace FuDever.Application.Features.Department.RestoreDepartmentByDepartmentId;

/// <summary>
///     Extension method for restore department
///     by department id feature.
/// </summary>
public static class RestoreDepartmentByDepartmentIdExtensionMethods
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
        this RestoreDepartmentByDepartmentIdResponseStatusCode statusCode
    )
    {
        return $"{nameof(Department)}.{nameof(RestoreDepartmentByDepartmentId)}.{(int)statusCode}";
    }
}
