using System.ComponentModel.DataAnnotations;
using FuDever.WebApi.DTOs.Others;

namespace FuDever.WebApi.DTOs.Hobby.Incomings;

/// <summary>
///     Incoming DTO for creating new hobby.
/// </summary>
public sealed class CreateHobbyDto : IDtoNormalization
{
    [Required]
    public string HobbyName { get; set; }

    public void NormalizeAllProperties()
    {
        HobbyName = HobbyName.Trim();
    }
}
