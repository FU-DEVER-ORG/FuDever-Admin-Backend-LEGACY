namespace FuDever.Application.Features.User.GetAllUsers;

/// <summary>
///     Get all users extension methods.
/// </summary>
public static class GetAllUsersExtensionMethods
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
    public static string ToAppCode(this GetAllUsersResponseStatusCode statusCode)
    {
        return $"{nameof(User)}.{nameof(GetAllUsers)}.{(int)statusCode}";
    }
}
