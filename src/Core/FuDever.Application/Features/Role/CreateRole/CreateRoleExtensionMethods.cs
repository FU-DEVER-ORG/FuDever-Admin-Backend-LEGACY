namespace FuDever.Application.Features.Role.CreateRole;

/// <summary>
///     Extension method for create role feature.
/// </summary>
public static class CreateRoleExtensionMethods
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
    public static string ToAppCode(this CreateRoleResponseStatusCode statusCode)
    {
        return $"{nameof(Role)}.{nameof(CreateRole)}.{(int)statusCode}";
    }
}
