using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FuDever.Application.Features.Auth.ChangingPassword;

/// <summary>
///     Changing Password request handler.
/// </summary>
internal sealed class ChangingPasswordRequestHandler
    : IRequestHandler<ChangingPasswordRequest, ChangingPasswordResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<Domain.Entities.User> _userManager;

    public ChangingPasswordRequestHandler(
        IUnitOfWork unitOfWork,
        UserManager<Domain.Entities.User> userManager
    )
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    public async Task<ChangingPasswordResponse> Handle(
        ChangingPasswordRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is reset password token found by its value.
        var isResetPasswordTokenFound =
            await _unitOfWork.AuthFeature.ChangingPassword.Query.IsResetPasswordTokenFoundByItsValueQueryAsync(
                passwordResetToken: request.ResetPasswordToken,
                cancellationToken: cancellationToken
            );

        // Reset password token is not found by its value.
        if (!isResetPasswordTokenFound)
        {
            return new()
            {
                StatusCode = ChangingPasswordResponseStatusCode.RESET_PASSWORD_TOKEN_IS_NOT_FOUND
            };
        }

        // Get the user token by reset password token.
        var foundUserToken =
            await _unitOfWork.AuthFeature.ChangingPassword.Query.FindUserTokenByResetPasswordTokenQueryAsync(
                passwordResetToken: request.ResetPasswordToken,
                cancellationToken: cancellationToken
            );

        // Find the user by user id.
        var foundUser = await _userManager.FindByIdAsync(userId: foundUserToken.UserId.ToString());

        // Is user not temporarily removed.
        var isUserNotTemporarilyRemoved =
            await _unitOfWork.AuthFeature.ChangingPassword.Query.IsUserNotTemporarilyRemovedQueryAsync(
                userId: foundUser.Id,
                cancellationToken: cancellationToken
            );

        // User is temporarily removed.
        if (!isUserNotTemporarilyRemoved)
        {
            return new()
            {
                StatusCode = ChangingPasswordResponseStatusCode.USER_IS_TEMPORARILY_REMOVED
            };
        }

        // Is new user password valid.
        var isPasswordValid = await ValidateUserPasswordAsync(
            newUser: foundUser,
            newPassword: request.NewPassword
        );

        // Password is not valid.
        if (!isPasswordValid)
        {
            return new()
            {
                StatusCode = ChangingPasswordResponseStatusCode.NEW_PASSWORD_IS_NOT_VALID
            };
        }

        // Reset user password with new password by reset password token.
        var resetPasswordResult = await _userManager.ResetPasswordAsync(
            user: foundUser,
            token: request.ResetPasswordToken,
            newPassword: request.NewPassword
        );

        // Cannot reset user password.
        if (!resetPasswordResult.Succeeded)
        {
            return new()
            {
                StatusCode = ChangingPasswordResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        // Remove the rset password token.
        var dbResult =
            await _unitOfWork.AuthFeature.ChangingPassword.Command.RemoveUserResetPasswordTokenCommandAsync(
                resetPasswordToken: request.ResetPasswordToken,
                cancellationToken: cancellationToken
            );

        // Cannot remove the reset password token.
        if (!dbResult)
        {
            return new()
            {
                StatusCode = ChangingPasswordResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new() { StatusCode = ChangingPasswordResponseStatusCode.OPERATION_SUCCESS };
    }

    #region Others
    /// <summary>
    ///     Validates the password of a newly created user.
    /// </summary>
    /// <param name="newUser">
    ///     The newly created user.
    /// </param>
    /// <param name="newPassword">
    ///     The password to be validated.
    /// </param>
    /// <returns>
    ///     True if the password is valid, False otherwise.
    /// </returns>
    private async Task<bool> ValidateUserPasswordAsync(
        Domain.Entities.User newUser,
        string newPassword
    )
    {
        IdentityResult result = default;

        foreach (var validator in _userManager.PasswordValidators)
        {
            result = await validator.ValidateAsync(
                manager: _userManager,
                user: newUser,
                password: newPassword
            );
        }

        if (Equals(objA: result, objB: default))
        {
            return false;
        }

        return result.Succeeded;
    }
    #endregion
}
