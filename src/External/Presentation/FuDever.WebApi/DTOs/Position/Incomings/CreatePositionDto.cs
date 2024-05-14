using System.ComponentModel.DataAnnotations;
using FuDever.WebApi.DTOs.Others;

namespace FuDever.WebApi.DTOs.Position.Incomings;

/// <summary>
///     Incoming DTO for creating new Position.
/// </summary>
public sealed class CreatePositionDto : IDtoNormalization
{
    [Required]
    public string PositionName { get; set; }

    public void NormalizeAllProperties()
    {
        PositionName = PositionName.Trim();
    }
}
