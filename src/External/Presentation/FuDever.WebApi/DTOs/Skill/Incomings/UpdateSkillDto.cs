using System.ComponentModel.DataAnnotations;
using FuDever.WebApi.DTOs.Others;

namespace FuDever.WebApi.DTOs.Skill.Incomings;

/// <summary>
///     Incoming DTO for updating existing Skill.
/// </summary>
public sealed class UpdateSkillDto : IDtoNormalization
{
    [Required]
    public string NewSkillName { get; set; }

    public void NormalizeAllProperties()
    {
        NewSkillName = NewSkillName.Trim();
    }
}
