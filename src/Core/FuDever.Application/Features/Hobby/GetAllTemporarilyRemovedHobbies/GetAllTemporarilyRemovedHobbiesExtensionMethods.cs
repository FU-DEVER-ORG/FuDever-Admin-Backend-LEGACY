namespace FuDever.Application.Features.Hobby.GetAllTemporarilyRemovedHobbies;

/// <summary>
///     Extension method for getting all temporarily
///     removed hobbies feature.
/// </summary>
public static class GetAllTemporarilyRemovedHobbiesExtensionMethods
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
        this GetAllTemporarilyRemovedHobbiesResponseStatusCode statusCode
    )
    {
        return $"{nameof(Hobby)}.{nameof(GetAllTemporarilyRemovedHobbies)}.{(int)statusCode}";
    }
}
