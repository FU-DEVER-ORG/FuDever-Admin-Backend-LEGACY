namespace FuDever.Application.Features.Skill.RemoveSkillTemporarilyBySkillId;

/// <summary>
///     Extension method for remove skill
///     temporarily by skill id feature.
/// </summary>
public static class RemoveSkillTemporarilyBySkillIdExtensionMethods
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
        this RemoveSkillTemporarilyBySkillIdResponseStatusCode statusCode
    )
    {
        return $"{nameof(Skill)}.{nameof(RemoveSkillTemporarilyBySkillId)}.{(int)statusCode}";
    }
}
