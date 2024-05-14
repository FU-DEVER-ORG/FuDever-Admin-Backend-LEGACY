namespace FuDever.Application.Features.Skill.RestoreSkillBySkillId;

/// <summary>
///     Extension method for restore skill
///     by skill id feature.
/// </summary>
public static class RestoreSkillBySkillIdExtensionMethods
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
    public static string ToAppCode(this RestoreSkillBySkillIdResponseStatusCode statusCode)
    {
        return $"{nameof(Skill)}.{nameof(RestoreSkillBySkillId)}.{(int)statusCode}";
    }
}
