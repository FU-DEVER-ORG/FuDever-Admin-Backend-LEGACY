namespace FuDever.Application.Features.Skill.GetAllSkillsBySkillName;

/// <summary>
///     Extension method for get all
///     skill by skill name feature.
/// </summary>
public static class GetAllSkillsBySkillNameExtensionMethods
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
    public static string ToAppCode(this GetAllSkillsBySkillNameResponseStatusCode statusCode)
    {
        return $"{nameof(Skill)}.{nameof(GetAllSkillsBySkillName)}.{(int)statusCode}";
    }
}
