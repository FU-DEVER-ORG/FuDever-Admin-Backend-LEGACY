namespace FuDever.Application.Features.Skill.GetAllTemporarilyRemovedSkills;

/// <summary>
///     Extension method for get all temporarily
///     removed skills feature.
/// </summary>
public static class GetAllTemporarilyRemovedSkillsExtensionMethods
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
    public static string ToAppCode(this GetAllTemporarilyRemovedSkillsResponseStatusCode statusCode)
    {
        return $"{nameof(Skill)}.{nameof(GetAllTemporarilyRemovedSkills)}.{(int)statusCode}";
    }
}
