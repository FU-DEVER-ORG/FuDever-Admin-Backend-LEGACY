using System.ComponentModel.DataAnnotations;
using FuDever.WebApi.DTOs.Others;

namespace FuDever.WebApi.DTOs.Major.Incomings;

/// <summary>
///     Incoming DTO for updating existing Major.
/// </summary>
public sealed class UpdateMajorDto : IDtoNormalization
{
    [Required]
    public string NewMajorName { get; set; }

    public void NormalizeAllProperties()
    {
        NewMajorName = NewMajorName.Trim();
    }
}
