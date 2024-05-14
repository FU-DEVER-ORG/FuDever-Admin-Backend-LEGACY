namespace FuDever.Application.Features.Role.RestoreRoleByRoleId;

/// <summary>
///     Extension method for restore role
///     by role id feature.
/// </summary>
public static class RestoreRoleByRoleIdExtensionMethods
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
    public static string ToAppCode(this RestoreRoleByRoleIdResponseStatusCode statusCode)
    {
        return $"{nameof(Role)}.{nameof(RestoreRoleByRoleId)}.{(int)statusCode}";
    }
}
