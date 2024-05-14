namespace FuDever.Application.Features.Hobby.GetAllHobbiesByHobbyName;

/// <summary>
///     Extension method for getting all
///     hobbies by hobby name feature.
/// </summary>
public static class GetAllHobbiesByHobbyNameExtensionMethods
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
    public static string ToAppCode(this GetAllHobbiesByHobbyNameResponseStatusCode statusCode)
    {
        return $"{nameof(Hobby)}.{nameof(GetAllHobbiesByHobbyName)}.{(int)statusCode}";
    }
}
