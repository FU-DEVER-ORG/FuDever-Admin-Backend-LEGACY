using System.ComponentModel.DataAnnotations;
using FuDever.WebApi.DTOs.Others;

namespace FuDever.WebApi.DTOs.Position.Incomings;

/// <summary>
///     Incoming DTO for updating existing Position.
/// </summary>
public sealed class UpdatePositionDto : IDtoNormalization
{
    [Required]
    public string NewPositionName { get; set; }

    public void NormalizeAllProperties()
    {
        NewPositionName = NewPositionName.Trim();
    }
}
