namespace FuDever.Application.Features.Department.GetAllDepartmentsByDepartmentName;

/// <summary>
///     Extension method for get all departments
///     by department name feature.
/// </summary>
public static class GetAllDepartmentsByDepartmentNameExtensionMethods
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
        this GetAllDepartmentsByDepartmentNameResponseStatusCode statusCode
    )
    {
        return $"{nameof(Department)}.{nameof(GetAllDepartmentsByDepartmentName)}.{(int)statusCode}";
    }
}
