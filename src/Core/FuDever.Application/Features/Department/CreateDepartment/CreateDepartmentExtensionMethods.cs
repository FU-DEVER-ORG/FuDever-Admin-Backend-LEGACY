namespace FuDever.Application.Features.Department.CreateDepartment;

/// <summary>
///     Extension method for create department feature.
/// </summary>
public static class CreateDepartmentExtensionMethods
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
    public static string ToAppCode(this CreateDepartmentResponseStatusCode statusCode)
    {
        return $"{nameof(Department)}.{nameof(CreateDepartment)}.{(int)statusCode}";
    }
}
