namespace FuDever.Application.Features.Role.GetAllRoles;

/// <summary>
///     Extension method for get all roles feature.
/// </summary>
public static class GetAllRolesExtensionMethods
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
    public static string ToAppCode(this GetAllRolesResponseStatusCode statusCode)
    {
        return $"{nameof(Role)}.{nameof(GetAllRoles)}.{(int)statusCode}";
    }
}
