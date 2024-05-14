namespace FuDever.Application.Features.Department.GetAllTemporarilyRemovedDepartments;

/// <summary>
///     Extension method for get all temporarily
///     removed departments feature.
/// </summary>
public static class GetAllTemporarilyRemovedDepartmentsExtensionMethods
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
        this GetAllTemporarilyRemovedDepartmentsResponseStatusCode statusCode
    )
    {
        return $"{nameof(Department)}.{nameof(GetAllTemporarilyRemovedDepartments)}.{(int)statusCode}";
    }
}
