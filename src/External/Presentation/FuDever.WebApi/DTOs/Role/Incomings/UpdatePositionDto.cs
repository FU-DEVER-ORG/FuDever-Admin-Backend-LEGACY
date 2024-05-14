using System.ComponentModel.DataAnnotations;
using FuDever.WebApi.DTOs.Others;

namespace FuDever.WebApi.DTOs.Role.Incomings;

/// <summary>
///     Incoming DTO for updating existing Role.
/// </summary>
public sealed class UpdateRoleDto : IDtoNormalization
{
    [Required]
    public string NewRoleName { get; set; }

    public void NormalizeAllProperties()
    {
        NewRoleName = NewRoleName.Trim();
    }
}
