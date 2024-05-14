namespace FuDever.Application.Features.Skill.UpdateSkillBySkillId;

/// <summary>
///     Extension method for update skill
///     by skill id feature.
/// </summary>
public static class UpdateSkillBySkillIdExtensionMethods
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
    public static string ToAppCode(this UpdateSkillBySkillIdResponseStatusCode statusCode)
    {
        return $"{nameof(Skill)}.{nameof(UpdateSkillBySkillId)}.{(int)statusCode}";
    }
}
