using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;

namespace FuDever.Application.Features.Auth.ConfirmUserRegistrationConfirmedEmail;

/// <summary>
///     Request handler for confirm user registration confirmed email request.
/// </summary>
internal sealed class ConfirmUserRegistrationConfirmedEmailRequestHandler
    : IRequestHandler<
        ConfirmUserRegistrationConfirmedEmailRequest,
        ConfirmUserRegistrationConfirmedEmailResponse
    >
{
    private readonly UserManager<Domain.Entities.User> _userManager;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IUnitOfWork _unitOfWork;

    public ConfirmUserRegistrationConfirmedEmailRequestHandler(
        UserManager<Domain.Entities.User> userManager,
        IWebHostEnvironment webHostEnvironment,
        IUnitOfWork unitOfWork
    )
    {
        _userManager = userManager;
        _webHostEnvironment = webHostEnvironment;
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
    public async Task<ConfirmUserRegistrationConfirmedEmailResponse> Handle(
        ConfirmUserRegistrationConfirmedEmailRequest request,
        CancellationToken cancellationToken
    )
    {
        const string AccountConfirmedUrlIsNotValidTemplateName =
            "AccountConfirmedUrlIsNotValidTemplate.html";
        const string UserHasAlreadyConfirmedAccountSuccessfullyTemplateName =
            "UserHasAlreadyConfirmedAccountSuccessfullyTemplate.html";
        const string UserHasConfirmedAccountSuccessfullyTemplateName =
            "UserHasConfirmedAccountSuccessfullyTemplate.html";
        const string ServerErrorTemplateName = "ServerErrorTemplate.html";

        byte[] decodedAccountCreationConfirmedEmailToken;

        try
        {
            // Decode token.
            decodedAccountCreationConfirmedEmailToken = WebEncoders.Base64UrlDecode(
                input: request.UserRegistrationEmailConfirmedTokenAsBase64
            );
        }
        catch
        {
            return new()
            {
                StatusCode =
                    ConfirmUserRegistrationConfirmedEmailResponseStatusCode.TOKEN_IS_NOT_IN_CORRECT_FORMAT,
                ResponseBodyAsHtml = await GenerateHtmlResponseAsync(
                    responseTemplateName: AccountConfirmedUrlIsNotValidTemplateName,
                    cancellationToken: cancellationToken
                )
            };
        }

        // Extract decoded token.
        var tokens = Encoding
            .UTF8.GetString(bytes: decodedAccountCreationConfirmedEmailToken)
            .Split(separator: "<token/>");

        // Get the user id.
        var userId = Guid.Parse(input: tokens[1]);

        // Find user by user id.
        var foundUser = await _userManager.FindByIdAsync(userId: userId.ToString());

        // User with user id does not exist.
        if (Equals(objA: foundUser, objB: default))
        {
            return new()
            {
                StatusCode =
                    ConfirmUserRegistrationConfirmedEmailResponseStatusCode.USER_IS_NOT_FOUND
            };
        }

        // Is user not temporarily removed.
        var isUserNotTemporarilyRemoved =
            await _unitOfWork.AuthFeature.ConfirmUserRegistrationConfirmedEmail.Query.IsUserNotTemporarilyRemovedQueryAsync(
                userId: foundUser.Id,
                cancellationToken: cancellationToken
            );

        // User is temporarily removed.
        if (!isUserNotTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    ConfirmUserRegistrationConfirmedEmailResponseStatusCode.USER_IS_TEMPORARILY_REMOVED
            };
        }

        // Has user confirmed account registration email.
        var hasUserConfirmed = await _userManager.IsEmailConfirmedAsync(user: foundUser);

        // User has confirmed account registration email.
        if (hasUserConfirmed)
        {
            return new()
            {
                StatusCode =
                    ConfirmUserRegistrationConfirmedEmailResponseStatusCode.USER_HAS_CONFIRMED_REGISTRATION_EMAIL,
                ResponseBodyAsHtml = await GenerateHtmlResponseAsync(
                    responseTemplateName: UserHasAlreadyConfirmedAccountSuccessfullyTemplateName,
                    cancellationToken: cancellationToken
                )
            };
        }

        // Confirm user account registration.
        var dbResult = await _userManager.ConfirmEmailAsync(
            user: foundUser,
            token: tokens[default]
        );

        // Cannot confirm user account registration email.
        if (!dbResult.Succeeded)
        {
            return new()
            {
                StatusCode =
                    ConfirmUserRegistrationConfirmedEmailResponseStatusCode.DATABASE_OPERATION_FAIL,
                ResponseBodyAsHtml = await GenerateHtmlResponseAsync(
                    responseTemplateName: ServerErrorTemplateName,
                    cancellationToken: cancellationToken
                )
            };
        }

        return new()
        {
            StatusCode = ConfirmUserRegistrationConfirmedEmailResponseStatusCode.OPERATION_SUCCESS,
            ResponseBodyAsHtml = await GenerateHtmlResponseAsync(
                responseTemplateName: UserHasConfirmedAccountSuccessfullyTemplateName,
                cancellationToken: cancellationToken
            )
        };
    }

    #region Others
    private Task<string> GenerateHtmlResponseAsync(
        string responseTemplateName,
        CancellationToken cancellationToken
    )
    {
        const string BaseCreateUserAccountFolderName = "CreateUserAccount";

        //Construct html template path.
        var userHasConfirmedAccountSuccessfullyHtmlPath = Path.Combine(
            path1: BaseCreateUserAccountFolderName,
            path2: responseTemplateName
        );

        var fullPath = Path.Combine(
            path1: _webHostEnvironment.WebRootPath,
            path2: userHasConfirmedAccountSuccessfullyHtmlPath
        );

        //Get the html template from file.
        return File.ReadAllTextAsync(path: fullPath, cancellationToken: cancellationToken);
    }
    #endregion
}
