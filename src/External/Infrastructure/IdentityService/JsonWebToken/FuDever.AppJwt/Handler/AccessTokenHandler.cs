using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using FuDever.Application.Shared.Authentication.Jwt;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace FuDever.AppJwt.Handler;

/// <summary>
///     Implementation of jwt generator interface.
/// </summary>
internal sealed class AccessTokenHandler : IAccessTokenHandler
{
    private readonly JsonWebTokenHandler _jsonWebTokenHandler;
    private readonly TokenValidationParameters _tokenValidationParameters;

    public AccessTokenHandler(
        JsonWebTokenHandler jsonWebTokenHandler,
        TokenValidationParameters tokenValidationParameters
    )
    {
        _jsonWebTokenHandler = jsonWebTokenHandler;
        _tokenValidationParameters = tokenValidationParameters;
    }

    public string GenerateSigningToken(IEnumerable<Claim> claims)
    {
        // Validate set of user claims.
        if (claims.Equals(obj: Enumerable.Empty<Claim>()) || Equals(objA: claims, objB: default))
        {
            return string.Empty;
        }

        SecurityTokenDescriptor tokenDescriptor =
            new()
            {
                Audience = _tokenValidationParameters.ValidAudience,
                Issuer = _tokenValidationParameters.ValidIssuer,
                Subject = new(claims: claims),
                Expires = DateTime.UtcNow.AddMinutes(value: 15),
                IssuedAt = DateTime.UtcNow,
                TokenType = "JWT",
                SigningCredentials = new(
                    key: _tokenValidationParameters.IssuerSigningKey,
                    algorithm: SecurityAlgorithms.HmacSha256
                )
            };

        return _jsonWebTokenHandler.CreateToken(tokenDescriptor: tokenDescriptor);
    }
}
