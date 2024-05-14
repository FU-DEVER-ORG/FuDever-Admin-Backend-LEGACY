namespace FuDever.Application.Features.Role.RemoveRolePermanentlyByRoleId;

/// <summary>
///     Extension method for remove role
///     permanently by role id feature.
/// </summary>
public static class RemoveRolePermanentlyByRoleIdExtensionMethods
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
    public static string ToAppCode(this RemoveRolePermanentlyByRoleIdResponseStatusCode statusCode)
    {
        return $"{nameof(Role)}.{nameof(RemoveRolePermanentlyByRoleId)}.{(int)statusCode}";
    }
}
