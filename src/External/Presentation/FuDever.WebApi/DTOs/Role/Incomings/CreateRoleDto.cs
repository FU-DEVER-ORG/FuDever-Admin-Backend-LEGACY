using System.ComponentModel.DataAnnotations;
using FuDever.WebApi.DTOs.Others;

namespace FuDever.WebApi.DTOs.Role.Incomings;

/// <summary>
///     Incoming DTO for creating new Role.
/// </summary>
public sealed class CreateRoleDto : IDtoNormalization
{
    [Required]
    public string RoleName { get; set; }

    public void NormalizeAllProperties()
    {
        RoleName = RoleName.Trim();
    }
}
