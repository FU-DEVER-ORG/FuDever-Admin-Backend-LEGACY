namespace FuDever.Application.Features.Department.UpdateDepartmentByDepartmentId;

/// <summary>
///     Extension method for update department
///     by department id feature.
/// </summary>
public static class UpdateDepartmentByDepartmentIdExtensionMethods
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
    public static string ToAppCode(this UpdateDepartmentByDepartmentIdResponseStatusCode statusCode)
    {
        return $"{nameof(Department)}.{nameof(UpdateDepartmentByDepartmentId)}.{(int)statusCode}";
    }
}
