using System.ComponentModel.DataAnnotations;
using FuDever.WebApi.DTOs.Others;

namespace FuDever.WebApi.DTOs.Hobby.Incomings;

/// <summary>
///     Incoming DTO for updating existing hobby.
/// </summary>
public sealed class UpdateHobbyDto : IDtoNormalization
{
    [Required]
    public string NewHobbyName { get; set; }

    public void NormalizeAllProperties()
    {
        NewHobbyName = NewHobbyName.Trim();
    }
}
