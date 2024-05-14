using System.ComponentModel.DataAnnotations;
using FuDever.WebApi.DTOs.Others;

namespace FuDever.WebApi.DTOs.Major.Incomings;

/// <summary>
///     Incoming DTO for creating new Major.
/// </summary>
public sealed class CreateMajorDto : IDtoNormalization
{
    [Required]
    public string MajorName { get; set; }

    public void NormalizeAllProperties()
    {
        MajorName = MajorName.Trim();
    }
}
