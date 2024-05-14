using System.ComponentModel.DataAnnotations;
using FuDever.WebApi.DTOs.Others;

namespace FuDever.WebApi.DTOs.Auth.Incomings;

/// <summary>
///     Dto for changing password.
/// </summary>
public sealed class ChangingPasswordDto : IDtoNormalization
{
    [Required]
    public string NewPassword { get; set; }

    [Required]
    public string ResetPasswordToken { get; set; }

    public void NormalizeAllProperties()
    {
        NewPassword = NewPassword.Trim();
        ResetPasswordToken = ResetPasswordToken.Trim();
    }
}
