namespace FuDever.Application.Features.Skill.RemoveSkillPermanentlyBySkillId;

/// <summary>
///     Extension method for remove skill
///     permanently by skill id feature.
/// </summary>
public static class RemoveSkillPermanentlyBySkillIdExtensionMethods
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
        this RemoveSkillPermanentlyBySkillIdResponseStatusCode statusCode
    )
    {
        return $"{nameof(Skill)}.{nameof(RemoveSkillPermanentlyBySkillId)}.{(int)statusCode}";
    }
}
