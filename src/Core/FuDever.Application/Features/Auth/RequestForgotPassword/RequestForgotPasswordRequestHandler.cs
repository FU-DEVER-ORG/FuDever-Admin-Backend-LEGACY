using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Mail;
using FuDever.Domain.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FuDever.Application.Features.Auth.RequestForgotPassword;

/// <summary>
///     Request Forgot Password request handler.
/// </summary>
internal sealed class RequestForgotPasswordRequestHandler
    : IRequestHandler<RequestForgotPasswordRequest, RequestForgotPasswordResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<Domain.Entities.User> _userManager;
    private readonly ISendingMailHandler _sendingMailHandler;

    public RequestForgotPasswordRequestHandler(
        IUnitOfWork unitOfWork,
        UserManager<Domain.Entities.User> userManager,
        ISendingMailHandler sendingMailHandler
    )
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _sendingMailHandler = sendingMailHandler;
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
    public async Task<RequestForgotPasswordResponse> Handle(
        RequestForgotPasswordRequest request,
        CancellationToken cancellationToken
    )
    {
        // Find user by username.
        var foundUser = await _userManager.FindByNameAsync(userName: request.Username);

        // User with username does not exist.
        if (Equals(objA: foundUser, objB: default))
        {
            return new() { StatusCode = RequestForgotPasswordResponseStatusCode.USER_IS_NOT_FOUND };
        }

        // Is user not temporarily removed.
        var isUserNotTemporarilyRemoved =
            await _unitOfWork.AuthFeature.RequestForgotPassword.Query.IsUserNotTemporarilyRemovedQueryAsync(
                userId: foundUser.Id,
                cancellationToken: cancellationToken
            );

        // User is temporarily removed.
        if (!isUserNotTemporarilyRemoved)
        {
            return new()
            {
                StatusCode = RequestForgotPasswordResponseStatusCode.USER_IS_TEMPORARILY_REMOVED
            };
        }

        // Generate password reset token.
        var passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(foundUser);

        // Add password reset token to database.
        var dbResult =
            await _unitOfWork.AuthFeature.RequestForgotPassword.Command.AddResetPasswordTokenToDatabase(
                newResetPasswordToken: InitNewResetPasswordToken(
                    userId: foundUser.Id,
                    passwordResetToken: passwordResetToken
                ),
                cancellationToken: cancellationToken
            );

        // Cannot add password reset token to database.
        if (!dbResult)
        {
            return new()
            {
                StatusCode = RequestForgotPasswordResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        // Sending user reset password mail.
        var mailSendingResult = await SendingResetPasswordMailToUserAsync(
            userName: foundUser.UserName,
            passwordResetToken: passwordResetToken,
            cancellationToken: cancellationToken
        );

        // Cannot send mail.
        if (!mailSendingResult)
        {
            return new()
            {
                StatusCode =
                    RequestForgotPasswordResponseStatusCode.SENDING_USER_RESET_PASSWORD_MAIL_FAIL
            };
        }

        return new() { StatusCode = RequestForgotPasswordResponseStatusCode.OPERATION_SUCCESS };
    }

    #region Others
    /// <summary>
    ///     Sends a confirmation mail to a newly created user.
    /// </summary>
    /// <param name="userName">
    ///     User with username.
    /// </param>
    /// <param name="passwordResetToken">
    ///     The password reset token of user.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token.
    /// </param>
    /// <returns>
    ///     Returns a task that represents the asynchronous operation. The task result
    ///     contains a value indicating whether the mail was sent successfully.
    /// </returns>
    private async Task<bool> SendingResetPasswordMailToUserAsync(
        string userName,
        string passwordResetToken,
        CancellationToken cancellationToken
    )
    {
        // Generate mail content.
        var mailContent = await _sendingMailHandler.GetUserResetPasswordMailContentAsync(
            to: userName,
            subject: "Changing password",
            resetPasswordToken: passwordResetToken,
            cancellationToken: cancellationToken
        );

        // Send mail to user.
        return await _sendingMailHandler.SendAsync(
            mailContent: mailContent,
            cancellationToken: cancellationToken
        );
    }

    private static Domain.Entities.UserToken InitNewResetPasswordToken(
        Guid userId,
        string passwordResetToken
    )
    {
        return new()
        {
            LoginProvider = Guid.NewGuid().ToString(),
            Name = "PasswordResetToken",
            UserId = userId,
            Value = passwordResetToken
        };
    }
    #endregion
}
