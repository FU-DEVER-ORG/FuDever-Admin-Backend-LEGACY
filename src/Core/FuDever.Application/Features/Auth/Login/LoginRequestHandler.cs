using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Authentication.Jwt;
using FuDever.Domain.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;

namespace FuDever.Application.Features.Auth.Login;

/// <summary>
///     Login request handler.
/// </summary>
internal sealed class LoginRequestHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<Domain.Entities.User> _userManager;
    private readonly SignInManager<Domain.Entities.User> _signInManager;
    private readonly IRefreshTokenHandler _refreshTokenHandler;
    private readonly IAccessTokenHandler _accessTokenHandler;

    public LoginRequestHandler(
        IUnitOfWork unitOfWork,
        UserManager<Domain.Entities.User> userManager,
        SignInManager<Domain.Entities.User> signInManager,
        IRefreshTokenHandler refreshTokenHandler,
        IAccessTokenHandler accessTokenHandler
    )
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _signInManager = signInManager;
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
    public async Task<LoginResponse> Handle(
        LoginRequest request,
        CancellationToken cancellationToken
    )
    {
        // Find user by username.
        var foundUser = await _userManager.FindByNameAsync(userName: request.Username);

        // User with username does not exist.
        if (Equals(objA: foundUser, objB: default))
        {
            return new() { StatusCode = LoginResponseStatusCode.USER_IS_NOT_FOUND };
        }

        // Does user have the current password.
        var doesUserHaveCurrentPassword = await _userManager.CheckPasswordAsync(
            user: foundUser,
            password: request.Password
        );

        // Password does not belong to user.
        if (!doesUserHaveCurrentPassword)
        {
            // Is user locked out.
            var userLockedOutResult = await _signInManager.CheckPasswordSignInAsync(
                user: foundUser,
                password: request.Password,
                lockoutOnFailure: true
            );

            // User is temporary locked out.
            if (userLockedOutResult.IsLockedOut)
            {
                return new() { StatusCode = LoginResponseStatusCode.USER_IS_LOCKED_OUT };
            }

            return new() { StatusCode = LoginResponseStatusCode.USER_PASSWORD_IS_NOT_CORRECT };
        }

        // Has user confirmed account creation email.
        var hasUserConfirmed = await _userManager.IsEmailConfirmedAsync(user: foundUser);

        // User has not confirmed account creation email.
        if (!hasUserConfirmed)
        {
            return new() { StatusCode = LoginResponseStatusCode.USER_EMAIL_IS_NOT_CONFIRMED };
        }

        // Get user joining status.
        var userDetail = await _unitOfWork.AuthFeature.Login.Query.GetUserJoiningStatusQueryAsync(
            userId: foundUser.Id,
            cancellationToken: cancellationToken
        );

        // User with user id is still pending.
        if (userDetail.UserJoiningStatus.Type.Equals(value: "Pending"))
        {
            return new() { StatusCode = LoginResponseStatusCode.USER_IS_STILL_PENDING };
        }

        // User with user id is already rejected.
        if (userDetail.UserJoiningStatus.Type.Equals(value: "Rejected"))
        {
            return new() { StatusCode = LoginResponseStatusCode.USER_IS_ALREADY_REJECTED };
        }

        // User with user id is already expired.
        if (userDetail.UserJoiningStatus.Type.Equals(value: "Expired"))
        {
            return new() { StatusCode = LoginResponseStatusCode.USER_IS_ALREADY_EXPIRED };
        }

        // Is user not temporarily removed.
        var isUserNotTemporarilyRemoved =
            await _unitOfWork.AuthFeature.Login.Query.IsUserNotTemporarilyRemovedQueryAsync(
                userId: foundUser.Id,
                cancellationToken: cancellationToken
            );

        // User is temporarily removed.
        if (!isUserNotTemporarilyRemoved)
        {
            return new() { StatusCode = LoginResponseStatusCode.USER_IS_TEMPORARILY_REMOVED };
        }

        // Get found user roles.
        var foundUserRoles = await _userManager.GetRolesAsync(user: foundUser);

        // Init list of user claims.
        List<Claim> userClaims =
        [
            new(type: JwtRegisteredClaimNames.Jti, value: Guid.NewGuid().ToString()),
            new(type: JwtRegisteredClaimNames.Sub, value: foundUser.Id.ToString()),
            new(type: "role", value: foundUserRoles[default])
        ];

        // Create new refresh token.
        var newRefreshToken = InitNewRefreshToken(
            userClaims: userClaims,
            isRememberMe: request.RememberMe
        );

        // Add new refresh token to the database.
        var dbResult = await _unitOfWork.AuthFeature.Login.Command.CreateRefreshTokenCommandAsync(
            newRefreshToken: newRefreshToken,
            cancellationToken: cancellationToken
        );

        // Cannot add new refresh token to the database.
        if (!dbResult)
        {
            return new() { StatusCode = LoginResponseStatusCode.DATABASE_OPERATION_FAIL };
        }

        // Generate access token.
        var newAccessToken = _accessTokenHandler.GenerateSigningToken(claims: userClaims);

        var userAvatarUrl = await _unitOfWork.AuthFeature.Login.Query.GetUserAvatarUrlQueryAsync(
            userId: foundUser.Id,
            cancellationToken: cancellationToken
        );

        return new()
        {
            StatusCode = LoginResponseStatusCode.OPERATION_SUCCESS,
            ResponseBody = new()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken.RefreshTokenValue,
                User = new() { Email = foundUser.Email, AvatarUrl = userAvatarUrl }
            }
        };
    }

    #region Others
    private Domain.Entities.RefreshToken InitNewRefreshToken(
        List<Claim> userClaims,
        bool isRememberMe
    )
    {
        return new()
        {
            AccessTokenId = Guid.Parse(
                input: userClaims
                    .First(predicate: claim =>
                        claim.Type.Equals(value: JwtRegisteredClaimNames.Jti)
                    )
                    .Value
            ),
            ExpiredDate = isRememberMe
                ? DateTime.UtcNow.AddDays(value: 7)
                : DateTime.UtcNow.AddDays(value: 3),
            CreatedAt = DateTime.UtcNow,
            RefreshTokenValue = _refreshTokenHandler.Generate(length: 15)
        };
    }
    #endregion
}
