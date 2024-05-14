namespace FuDever.Application.Features.Skill.CreateSkill;

/// <summary>
///     Extension method for create skill feature.
/// </summary>
public static class CreateSkillExtensionMethods
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
    public static string ToAppCode(this CreateSkillResponseStatusCode statusCode)
    {
        return $"{nameof(Skill)}.{nameof(CreateSkill)}.{(int)statusCode}";
    }
}
