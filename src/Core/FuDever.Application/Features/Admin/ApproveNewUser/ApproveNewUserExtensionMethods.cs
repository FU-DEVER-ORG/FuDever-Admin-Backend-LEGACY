namespace FuDever.Application.Features.Admin.ApproveNewUser;

/// <summary>
///     Extension method for approve new user response.
/// </summary>
public static class ApproveNewUserExtensionMethods
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
    public static string ToAppCode(this ApproveNewUserResponseStatusCode statusCode)
    {
        return $"{nameof(Admin)}.{nameof(ApproveNewUser)}.{(int)statusCode}";
    }
}
