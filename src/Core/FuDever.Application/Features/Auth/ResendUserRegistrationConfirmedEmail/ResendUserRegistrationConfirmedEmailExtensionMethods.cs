namespace FuDever.Application.Features.Auth.ResendUserRegistrationConfirmedEmail;

/// <summary>
///     Extension method for resend user registration confirmed email feature.
/// </summary>
public static class ResendUserRegistrationConfirmedEmailExtensionMethods
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
        this ResendUserRegistrationConfirmedEmailResponseStatusCode statusCode
    )
    {
        return $"{nameof(Auth)}.{nameof(ResendUserRegistrationConfirmedEmail)}.{(int)statusCode}";
    }
}
