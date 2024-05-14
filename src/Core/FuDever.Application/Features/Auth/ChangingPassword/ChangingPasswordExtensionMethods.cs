namespace FuDever.Application.Features.Auth.ChangingPassword;

/// <summary>
///     Extension method for changing password feature.
/// </summary>
public static class ChangingPasswordExtensionMethods
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
    public static string ToAppCode(this ChangingPasswordResponseStatusCode statusCode)
    {
        return $"{nameof(Auth)}.{nameof(ChangingPassword)}.{(int)statusCode}";
    }
}
