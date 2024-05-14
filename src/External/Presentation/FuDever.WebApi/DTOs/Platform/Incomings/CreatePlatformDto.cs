using System.ComponentModel.DataAnnotations;
using FuDever.WebApi.DTOs.Others;

namespace FuDever.WebApi.DTOs.Platform.Incomings;

/// <summary>
///     Incoming DTO for creating new Platform.
/// </summary>
public sealed class CreatePlatformDto : IDtoNormalization
{
    [Required]
    public string PlatformName { get; set; }

    public void NormalizeAllProperties()
    {
        PlatformName = PlatformName.Trim();
    }
}
