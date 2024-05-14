namespace FuDever.Application.Features.Auth.RegisterAsUser;

/// <summary>
///     Extension method for register feature.
/// </summary>
public static class RegisterAsUserExtensionMethods
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
    public static string ToAppCode(this RegisterAsUserResponseStatusCode statusCode)
    {
        return $"{nameof(Auth)}.{nameof(RegisterAsUser)}.{(int)statusCode}";
    }
}
