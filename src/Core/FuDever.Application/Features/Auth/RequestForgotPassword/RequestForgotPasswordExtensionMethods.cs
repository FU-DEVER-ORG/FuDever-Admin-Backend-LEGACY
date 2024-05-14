namespace FuDever.Application.Features.Auth.RequestForgotPassword;

/// <summary>
///      Request Forgot Password extension methods.
/// </summary>
public static class RequestForgotPasswordExtensionMethods
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
    public static string ToAppCode(this RequestForgotPasswordResponseStatusCode statusCode)
    {
        return $"{nameof(Auth)}.{nameof(RequestForgotPassword)}.{(int)statusCode}";
    }
}
