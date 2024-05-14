using System.Security.Cryptography;
using System.Text;
using FuDever.Application.Shared.Authentication.Jwt;
using FuDever.Domain.Entities;

namespace FuDever.AppJwt.Handler;

/// <summary>
///     Implementation refresh token generator interface.
/// </summary>
internal sealed class RefreshTokenHandler : IRefreshTokenHandler
{
    public string Generate(int length)
    {
        const string Chars =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz!@#$%^&*+=";

        if (
            length < RefreshToken.Metadata.RefreshTokenValue.MinLength
            || length > RefreshToken.Metadata.RefreshTokenValue.MaxLength
        )
        {
            return string.Empty;
        }

        StringBuilder builder = new();

        for (int time = default; time < length; time++)
        {
            builder.Append(
                value: Chars[index: RandomNumberGenerator.GetInt32(toExclusive: Chars.Length)]
            );
        }

        return builder.ToString();
    }
}
