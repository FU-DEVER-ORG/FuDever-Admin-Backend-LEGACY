namespace FuDever.Application.Features.Skill.RemoveSkillPermanentlyBySkillId;

/// <summary>
///     Remove skill permanently by skill id response status code.
/// </summary>
public enum RemoveSkillPermanentlyBySkillIdResponseStatusCode
{
    INPUT_VALIDATION_FAIL,
    OPERATION_SUCCESS,
    DATABASE_OPERATION_FAIL,
    SKILL_IS_NOT_FOUND,
    SKILL_IS_NOT_TEMPORARILY_REMOVED,
    FORBIDDEN,
    UN_AUTHORIZED
}
