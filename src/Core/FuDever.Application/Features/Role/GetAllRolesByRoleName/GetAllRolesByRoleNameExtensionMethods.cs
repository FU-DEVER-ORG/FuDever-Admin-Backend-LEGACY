namespace FuDever.Application.Features.Role.GetAllRolesByRoleName;

/// <summary>
///     Extension method for get all roles
///     by role name feature.
/// </summary>
public static class GetAllRolesByRoleNameExtensionMethods
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
    public static string ToAppCode(this GetAllRolesByRoleNameResponseStatusCode statusCode)
    {
        return $"{nameof(Role)}.{nameof(GetAllRolesByRoleName)}.{(int)statusCode}";
    }
}
