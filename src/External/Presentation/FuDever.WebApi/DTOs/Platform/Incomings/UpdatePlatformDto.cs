using System.ComponentModel.DataAnnotations;
using FuDever.WebApi.DTOs.Others;

namespace FuDever.WebApi.DTOs.Platform.Incomings;

/// <summary>
///     Incoming DTO for updating existing Platform.
/// </summary>
public sealed class UpdatePlatformDto : IDtoNormalization
{
    [Required]
    public string NewPlatformName { get; set; }

    public void NormalizeAllProperties()
    {
        NewPlatformName = NewPlatformName.Trim();
    }
}
