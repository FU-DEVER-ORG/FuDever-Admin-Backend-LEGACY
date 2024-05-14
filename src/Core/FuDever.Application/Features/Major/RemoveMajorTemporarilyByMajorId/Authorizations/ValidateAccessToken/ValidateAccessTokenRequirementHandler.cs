using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Authorization;
using FuDever.Domain.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace FuDever.Application.Features.Major.RemoveMajorTemporarilyByMajorId.Authorizations.ValidateAccessToken;

/// <summary>
///     Responsible for validating access token.
/// </summary>
internal sealed class ValidateAccessTokenRequirementHandler
    : IAppAuthorizationRequirementHandler<ValidateAccessTokenRequirement>
{
    private readonly TokenValidationParameters _tokenValidationParameters;
    private readonly JsonWebTokenHandler _jsonWebTokenHandler;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<Domain.Entities.User> _userManager;

    public ValidateAccessTokenRequirementHandler(
        TokenValidationParameters tokenValidationParameters,
        IHttpContextAccessor httpContextAccessor,
        JsonWebTokenHandler jsonWebTokenHandler,
        IUnitOfWork unitOfWork,
        UserManager<Domain.Entities.User> userManager
    )
    {
        _unitOfWork = unitOfWork;
        _tokenValidationParameters = tokenValidationParameters;
        _jsonWebTokenHandler = jsonWebTokenHandler;
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
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
    public async Task<AppAuthorizationResult> Handle(
        ValidateAccessTokenRequirement request,
        CancellationToken cancellationToken
    )
    {
        // Find the authorization header.
        var authorizationHeader =
            _httpContextAccessor.HttpContext.Request.Headers.Authorization.FirstOrDefault();

        // Header is not found.
        if (
            string.IsNullOrWhiteSpace(value: authorizationHeader)
            || !authorizationHeader.StartsWith(value: "Bearer")
        )
        {
            return AppAuthorizationResult.UnAuthorized();
        }

        var authorizationValueTokens = authorizationHeader.Split(separator: " ");

        if (authorizationValueTokens.Length != 2)
        {
            return AppAuthorizationResult.UnAuthorized();
        }

        // Get the access token from the authorization header.
        var accessToken = authorizationValueTokens[1];

        // Validate access token.
        var validateTokenResult = await _jsonWebTokenHandler.ValidateTokenAsync(
            token: accessToken,
            validationParameters: _tokenValidationParameters
        );

        // Token is not valid.
        if (!validateTokenResult.IsValid)
        {
            return AppAuthorizationResult.Forbidden();
        }

        // Get the jti claim from the access token.
        var jtiClaim = _httpContextAccessor.HttpContext.User.FindFirstValue(
            claimType: JwtRegisteredClaimNames.Jti
        );

        // Does refresh token exist by access token id.
        var isRefreshTokenFound =
            await _unitOfWork.MajorFeature.RemoveMajorTemporarilyByMajorId.Query.IsRefreshTokenFoundByAccessTokenIdQueryAsync(
                accessTokenId: Guid.Parse(input: jtiClaim),
                cancellationToken: cancellationToken
            );

        // Refresh token is not found by access token id.
        if (!isRefreshTokenFound)
        {
            return AppAuthorizationResult.Forbidden();
        }

        // Get the sub claim from the access token.
        var subClaim = _httpContextAccessor.HttpContext.User.FindFirstValue(
            claimType: JwtRegisteredClaimNames.Sub
        );

        // Find user by user id.
        var foundUser = await _userManager.FindByIdAsync(
            userId: Guid.Parse(input: subClaim).ToString()
        );

        // User is not found
        if (Equals(objA: foundUser, objB: default))
        {
            return AppAuthorizationResult.Forbidden();
        }

        // Is user not temporarily removed.
        var isUserNotTemporarilyRemoved =
            await _unitOfWork.MajorFeature.RemoveMajorTemporarilyByMajorId.Query.IsUserNotTemporarilyRemovedQueryAsync(
                userId: foundUser.Id,
                cancellationToken: cancellationToken
            );

        // User is temporarily removed.
        if (!isUserNotTemporarilyRemoved)
        {
            return AppAuthorizationResult.Forbidden();
        }

        // Get the role claim from the access token.
        var roleClaim = _httpContextAccessor.HttpContext.User.FindFirstValue(claimType: "role");

        // This user is not admin.
        if (!roleClaim.Equals(value: "admin"))
        {
            return AppAuthorizationResult.Forbidden();
        }

        // Is user in role.
        var isUserInRole = await _userManager.IsInRoleAsync(user: foundUser, role: roleClaim);

        // User is not in role.
        if (!isUserInRole)
        {
            return AppAuthorizationResult.Forbidden();
        }

        return AppAuthorizationResult.Authorized();
    }
}
