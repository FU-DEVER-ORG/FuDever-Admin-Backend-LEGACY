using System.ComponentModel.DataAnnotations;
using FuDever.WebApi.DTOs.Others;

namespace FuDever.WebApi.DTOs.Auth.Incomings;

/// <summary>
///     Forgot password dto.
/// </summary>
public sealed class ForgotPasswordDto : IDtoNormalization
{
    [Required]
    public string Username { get; set; }

    public void NormalizeAllProperties()
    {
        Username = Username.Trim();
    }
}
