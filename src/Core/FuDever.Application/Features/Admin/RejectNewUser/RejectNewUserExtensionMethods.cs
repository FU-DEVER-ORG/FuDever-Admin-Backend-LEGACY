namespace FuDever.Application.Features.Admin.RejectNewUser;

/// <summary>
///     Extension methods for reject new user feature.
/// </summary>
public static class RejectNewUserExtensionMethods
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
    public static string ToAppCode(this RejectNewUserResponseStatusCode statusCode)
    {
        return $"{nameof(Admin)}.{nameof(RejectNewUser)}.{(int)statusCode}";
    }
}
