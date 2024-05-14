namespace FuDever.Application.Features.Major.GetAllTemporarilyRemovedMajors;

/// <summary>
///     Extension method for get all
///     temporarily removed majors feature.
/// </summary>
public static class GetAllTemporarilyRemovedMajorsExtensionMethods
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
    public static string ToAppCode(this GetAllTemporarilyRemovedMajorsResponseStatusCode statusCode)
    {
        return $"{nameof(Major)}.{nameof(GetAllTemporarilyRemovedMajors)}.{(int)statusCode}";
    }
}
