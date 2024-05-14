namespace FuDever.Application.Features.Role.GetAllTemporarilyRemovedRoles;

/// <summary>
///     Extension method for get all temporarily removed role feature.
/// </summary>
public static class GetAllTemporarilyRemovedRolesExtensionMethods
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
    public static string ToAppCode(this GetAllTemporarilyRemovedRolesResponseStatusCode statusCode)
    {
        return $"{nameof(Role)}.{nameof(GetAllTemporarilyRemovedRoles)}.{(int)statusCode}";
    }
}
