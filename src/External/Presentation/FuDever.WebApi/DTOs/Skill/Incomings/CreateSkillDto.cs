using System.ComponentModel.DataAnnotations;
using FuDever.WebApi.DTOs.Others;

namespace FuDever.WebApi.DTOs.Skill.Incomings;

/// <summary>
///     Incoming DTO for creating new Skill.
/// </summary>
public sealed class CreateSkillDto : IDtoNormalization
{
    [Required]
    public string SkillName { get; set; }

    public void NormalizeAllProperties()
    {
        SkillName = SkillName.Trim();
    }
}
