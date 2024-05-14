namespace FuDever.Application.Features.Department.GetAllDepartments;

/// <summary>
///     Extension method for get all departments feature.
/// </summary>
public static class GetAllDepartmentsExtensionMethods
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
    public static string ToAppCode(this GetAllDepartmentsResponseStatusCode statusCode)
    {
        return $"{nameof(Department)}.{nameof(GetAllDepartments)}.{(int)statusCode}";
    }
}
