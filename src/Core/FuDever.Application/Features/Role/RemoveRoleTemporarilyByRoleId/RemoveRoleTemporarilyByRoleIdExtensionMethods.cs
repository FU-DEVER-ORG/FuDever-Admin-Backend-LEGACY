namespace FuDever.Application.Features.Role.RemoveRoleTemporarilyByRoleId;

/// <summary>
///     Extension method for remove role
///     temporarily by role id feature.
/// </summary>
public static class RemoveRoleTemporarilyByRoleIdExtensionMethods
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
    public static string ToAppCode(this RemoveRoleTemporarilyByRoleIdResponseStatusCode statusCode)
    {
        return $"{nameof(Role)}.{nameof(RemoveRoleTemporarilyByRoleId)}.{(int)statusCode}";
    }
}
