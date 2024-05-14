using System.ComponentModel.DataAnnotations;
using FuDever.WebApi.DTOs.Others;

namespace FuDever.WebApi.DTOs.Auth.Incomings;

/// <summary>
///     Dto for resend user registration confirmed email api.
/// </summary>
public sealed class ResendUserRegistrationConfirmedEmailDto : IDtoNormalization
{
    [Required]
    public string Username { get; set; }

    public void NormalizeAllProperties()
    {
        Username = Username.Trim();
    }
}
