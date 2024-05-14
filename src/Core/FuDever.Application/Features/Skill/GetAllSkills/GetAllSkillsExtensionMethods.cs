namespace FuDever.Application.Features.Skill.GetAllSkills;

/// <summary>
///     Extension method for get all skill feature.
/// </summary>
public static class GetAllSkillsExtensionMethods
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
    public static string ToAppCode(this GetAllSkillsResponseStatusCode statusCode)
    {
        return $"{nameof(Skill)}.{nameof(GetAllSkills)}.{(int)statusCode}";
    }
}
