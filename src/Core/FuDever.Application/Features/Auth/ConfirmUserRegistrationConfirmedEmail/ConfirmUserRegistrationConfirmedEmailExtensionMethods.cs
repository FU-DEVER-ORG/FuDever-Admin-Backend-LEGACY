namespace FuDever.Application.Features.Auth.ConfirmUserRegistrationConfirmedEmail;

/// <summary>
///     Extension method for confirm user registration email feature.
/// </summary>
public static class ConfirmUserRegistrationConfirmedEmailExtensionMethods
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
    public static string ToAppCode(
        this ConfirmUserRegistrationConfirmedEmailResponseStatusCode statusCode
    )
    {
        return $"{nameof(Auth)}.{nameof(ConfirmUserRegistrationConfirmedEmail)}.{(int)statusCode}";
    }
}
