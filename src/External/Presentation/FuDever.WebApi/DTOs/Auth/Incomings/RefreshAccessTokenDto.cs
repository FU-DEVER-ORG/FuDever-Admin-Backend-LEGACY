using System.ComponentModel.DataAnnotations;
using FuDever.WebApi.DTOs.Others;

namespace FuDever.WebApi.DTOs.Auth.Incomings;

/// <summary>
///     Dto for refresh access token.
/// </summary>
public sealed class RefreshAccessTokenDto : IDtoNormalization
{
    [Required]
    public string RefreshToken { get; set; }

    public void NormalizeAllProperties()
    {
        RefreshToken = RefreshToken.Trim();
    }
}
