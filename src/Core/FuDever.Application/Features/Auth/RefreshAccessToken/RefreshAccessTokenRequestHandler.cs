using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Authentication.Jwt;
using FuDever.Domain.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;

namespace FuDever.Application.Features.Auth.RefreshAccessToken;

/// <summary>
///     Refresh access token request handler.
/// </summary>
internal sealed class RefreshAccessTokenRequestHandler
    : IRequestHandler<RefreshAccessTokenRequest, RefreshAccessTokenResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IRefreshTokenHandler _refreshTokenHandler;
    private readonly IAccessTokenHandler _accessTokenHandler;

    public RefreshAccessTokenRequestHandler(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor,
        IRefreshTokenHandler refreshTokenHandler,
        IAccessTokenHandler accessTokenHandler
    )
    {
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
        _refreshTokenHandler = refreshTokenHandler;
        _accessTokenHandler = accessTokenHandler;
    }

    /// <summary>
    ///     Entry of new request handler.
    /// </summary>
    /// <param name="request">
    ///     Request model.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used for notifying system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     A task containing the response.
    /// </returns>
    public async Task<RefreshAccessTokenResponse> Handle(
        RefreshAccessTokenRequest request,
        CancellationToken cancellationToken
    )
    {
        // Find refresh token by its value.
        var foundRefreshToken =
            await _unitOfWork.AuthFeature.RefreshAccessToken.Query.FindByRefreshTokenValueQueryAsync(
                refreshTokenValue: request.RefreshToken,
                cancellationToken: cancellationToken
            );

        // Refresh token is not found by refresh token value.
        if (Equals(objA: foundRefreshToken, objB: default))
        {
            return new()
            {
                StatusCode = RefreshAccessTokenResponseStatusCode.REFRESH_TOKEN_IS_NOT_FOUND
            };
        }

        // Refresh token is expired.
        if (DateTime.UtcNow > foundRefreshToken.ExpiredDate)
        {
            return new()
            {
                StatusCode = RefreshAccessTokenResponseStatusCode.REFRESH_TOKEN_IS_EXPIRED
            };
        }

        // Init new list of user claims.
        List<Claim> userClaims =
        [
            new(type: JwtRegisteredClaimNames.Jti, value: Guid.NewGuid().ToString()),
            new(
                type: JwtRegisteredClaimNames.Sub,
                value: _httpContextAccessor.HttpContext.User.FindFirstValue(
                    claimType: JwtRegisteredClaimNames.Sub
                )
            ),
            new(
                type: ClaimTypes.Role,
                value: _httpContextAccessor.HttpContext.User.FindFirstValue(claimType: "role")
            )
        ];

        // Generate new refresh token value.
        var newRefreshTokenValue = _refreshTokenHandler.Generate(length: 15);

        // Update current refresh token.
        var dbResult =
            await _unitOfWork.AuthFeature.RefreshAccessToken.Command.UpdateRefreshTokenCommandAsync(
                oldRefreshTokenValue: request.RefreshToken,
                newRefreshTokenValue: newRefreshTokenValue,
                newAccessTokenId: Guid.Parse(input: userClaims[0].Value),
                cancellationToken: cancellationToken
            );

        // Cannot update current refresh token.
        if (!dbResult)
        {
            return new()
            {
                StatusCode = RefreshAccessTokenResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        // Generate new access token.
        var newAccessToken = _accessTokenHandler.GenerateSigningToken(claims: userClaims);

        return new()
        {
            StatusCode = RefreshAccessTokenResponseStatusCode.OPERATION_SUCCESS,
            ResponseBody = new()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshTokenValue
            }
        };
    }
}
