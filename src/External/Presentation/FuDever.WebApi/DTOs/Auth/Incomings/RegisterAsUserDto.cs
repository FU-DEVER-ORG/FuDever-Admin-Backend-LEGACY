using System.ComponentModel.DataAnnotations;
using FuDever.WebApi.DTOs.Others;

namespace FuDever.WebApi.DTOs.Auth.Incomings;

/// <summary>
///     Dto for register as user api.
/// </summary>
public sealed class RegisterAsUserDto : IDtoNormalization
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

    public void NormalizeAllProperties()
    {
        Username = Username.Trim();
        Password = Password.Trim();
    }
}
