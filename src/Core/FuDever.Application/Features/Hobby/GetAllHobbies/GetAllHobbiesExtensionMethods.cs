namespace FuDever.Application.Features.Hobby.GetAllHobbies;

/// <summary>
///     Extension method for get all hobbies feature.
/// </summary>
public static class GetAllHobbiesExtensionMethods
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
    public static string ToAppCode(this GetAllHobbiesResponseStatusCode statusCode)
    {
        return $"{nameof(Hobby)}.{nameof(GetAllHobbies)}.{(int)statusCode}";
    }
}
