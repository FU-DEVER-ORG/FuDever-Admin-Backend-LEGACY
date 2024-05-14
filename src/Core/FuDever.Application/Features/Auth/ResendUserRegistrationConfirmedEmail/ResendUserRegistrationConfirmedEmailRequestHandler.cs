using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Mail;
using FuDever.Domain.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;

namespace FuDever.Application.Features.Auth.ResendUserRegistrationConfirmedEmail;

/// <summary>
///     Request handler for resending user registration confirmed email.
/// </summary>
internal sealed class ResendUserRegistrationConfirmedEmailRequestHandler
    : IRequestHandler<
        ResendUserRegistrationConfirmedEmailRequest,
        ResendUserRegistrationConfirmedEmailResponse
    >
{
    private readonly UserManager<Domain.Entities.User> _userManager;
    private readonly ISendingMailHandler _sendingMailHandler;
    private readonly IUnitOfWork _unitOfWork;

    public ResendUserRegistrationConfirmedEmailRequestHandler(
        UserManager<Domain.Entities.User> userManager,
        ISendingMailHandler sendingMailHandler,
        IUnitOfWork unitOfWork
    )
    {
        _userManager = userManager;
        _sendingMailHandler = sendingMailHandler;
        _unitOfWork = unitOfWork;
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
    public async Task<ResendUserRegistrationConfirmedEmailResponse> Handle(
        ResendUserRegistrationConfirmedEmailRequest request,
        CancellationToken cancellationToken
    )
    {
        // Find user by user name.
        var foundUser = await _userManager.FindByNameAsync(userName: request.Username);

        // User with user name does not exist.
        if (Equals(objA: foundUser, objB: default))
        {
            return new()
            {
                StatusCode =
                    ResendUserRegistrationConfirmedEmailResponseStatusCode.USER_IS_NOT_FOUND
            };
        }

        // Is user not temporarily removed.
        var isUserNotTemporarilyRemoved =
            await _unitOfWork.AuthFeature.ResendUserRegistrationConfirmedEmail.Query.IsUserNotTemporarilyRemovedQueryAsync(
                userId: foundUser.Id,
                cancellationToken: cancellationToken
            );

        // User is temporarily removed.
        if (!isUserNotTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    ResendUserRegistrationConfirmedEmailResponseStatusCode.USER_IS_TEMPORARILY_REMOVED
            };
        }

        // Has user confirm account creation email.
        var hasUserConfirmed = await _userManager.IsEmailConfirmedAsync(user: foundUser);

        // User has confirmed account creation email.
        if (hasUserConfirmed)
        {
            return new()
            {
                StatusCode =
                    ResendUserRegistrationConfirmedEmailResponseStatusCode.USER_HAS_CONFIRMED_EMAIL
            };
        }

        // Send account creation confirmation mail to user.
        var mailSendingResult = await SendingConfirmationMailToUserAsync(
            newUser: foundUser,
            cancellationToken: cancellationToken
        );

        // Cannot send mail.
        if (!mailSendingResult)
        {
            return new()
            {
                StatusCode =
                    ResendUserRegistrationConfirmedEmailResponseStatusCode.SENDING_USER_CONFIRMATION_MAIL_FAIL
            };
        }

        return new()
        {
            StatusCode = ResendUserRegistrationConfirmedEmailResponseStatusCode.OPERATION_SUCCESS
        };
    }

    #region Others
    /// <summary>
    ///     Sends a confirmation mail to a newly created user.
    /// </summary>
    /// <param name="newUser">
    ///     The newly created user.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token.
    /// </param>
    /// <returns>
    ///     Returns a task that represents the asynchronous operation. The task result
    ///     contains a value indicating whether the mail was sent successfully.
    /// </returns>
    private async Task<bool> SendingConfirmationMailToUserAsync(
        Domain.Entities.User newUser,
        CancellationToken cancellationToken
    )
    {
        const string RegistrationConfirmEmailRoutePatuh = "api/auth/sign-up/confirm-email?token=";

        // Init main account creation confirmed email token.
        var accountCreationConfirmedEmailToken_1 =
            await _userManager.GenerateEmailConfirmationTokenAsync(user: newUser);

        // Convert to utf-8 byte array.
        var accountCreationConfirmedEmailTokenAsBytes_1 = Encoding.UTF8.GetBytes(
            s: $"{accountCreationConfirmedEmailToken_1}<token/>{newUser.Id}"
        );

        // Convert to base 64 format.
        var accountCreationConfirmedEmailTokenAsBase64_1 = WebEncoders.Base64UrlEncode(
            input: accountCreationConfirmedEmailTokenAsBytes_1
        );

        // Init secondary account creation confirmed email token.
        var accountCreationConfirmedEmailToken_2 =
            await _userManager.GenerateEmailConfirmationTokenAsync(user: newUser);

        // Convert to utf-8 byte array.
        var accountCreationConfirmedEmailTokenAsBytes_2 = Encoding.UTF8.GetBytes(
            s: $"{accountCreationConfirmedEmailToken_2}<token/>{newUser.Id}"
        );

        // Convert to base 64 format.
        var accountCreationConfirmedEmailTokenAsBase64_2 = WebEncoders.Base64UrlEncode(
            input: accountCreationConfirmedEmailTokenAsBytes_2
        );

        // Init new email for account confirmation.
        var mailContent = await _sendingMailHandler.GetUserAccountConfirmationMailContentAsync(
            to: newUser.UserName,
            subject: "Confirm account registration",
            mainVerifyLink: RegistrationConfirmEmailRoutePatuh
                + accountCreationConfirmedEmailTokenAsBase64_1,
            alternativeVerifyLink: RegistrationConfirmEmailRoutePatuh
                + accountCreationConfirmedEmailTokenAsBase64_2,
            cancellationToken: cancellationToken
        );

        // Send mail to user.
        return await _sendingMailHandler.SendAsync(
            mailContent: mailContent,
            cancellationToken: cancellationToken
        );
    }
    #endregion
}
