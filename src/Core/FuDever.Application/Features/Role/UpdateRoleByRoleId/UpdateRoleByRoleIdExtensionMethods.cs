namespace FuDever.Application.Features.Role.UpdateRoleByRoleId;

/// <summary>
///     Extension method for update role
///     by role id feature.
/// </summary>
public static class UpdateRoleByRoleIdExtensionMethods
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
    public static string ToAppCode(this UpdateRoleByRoleIdResponseStatusCode statusCode)
    {
        return $"{nameof(Role)}.{nameof(UpdateRoleByRoleId)}.{(int)statusCode}";
    }
}
