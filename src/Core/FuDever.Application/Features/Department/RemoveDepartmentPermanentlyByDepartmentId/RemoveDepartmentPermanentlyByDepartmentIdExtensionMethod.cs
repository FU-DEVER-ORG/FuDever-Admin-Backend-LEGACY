namespace FuDever.Application.Features.Department.RemoveDepartmentPermanentlyByDepartmentId;

/// <summary>
///     Extension method for remove department permanently
///     by department id feature.
/// </summary>
public static class RemoveDepartmentPermanentlyByDepartmentIdExtensionMethod
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
        this RemoveDepartmentPermanentlyByDepartmentIdResponseStatusCode statusCode
    )
    {
        return $"{nameof(Department)}.{nameof(RemoveDepartmentPermanentlyByDepartmentId)}.{(int)statusCode}";
    }
}
