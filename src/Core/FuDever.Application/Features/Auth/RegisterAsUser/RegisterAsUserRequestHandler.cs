using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Commons;
using FuDever.Application.Shared.Data;
using FuDever.Application.Shared.FIleObjectStorage;
using FuDever.Application.Shared.Mail;
using FuDever.Domain.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;

namespace FuDever.Application.Features.Auth.RegisterAsUser;

/// <summary>
///     Register as user request handler.
/// </summary>
internal sealed class RegisterAsUserRequestHandler
    : IRequestHandler<RegisterAsUserRequest, RegisterAsUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<Domain.Entities.User> _userManager;
    private readonly ISendingMailHandler _sendingMailHandler;
    private readonly IDbMinTimeHandler _dbMinTimeHandler;
    private readonly IDefaultUserAvatarAsUrlHandler _defaultUserAvatarAsUrlHandler;

    public RegisterAsUserRequestHandler(
        IUnitOfWork unitOfWork,
        UserManager<Domain.Entities.User> userManager,
        ISendingMailHandler sendingMailHandler,
        IDbMinTimeHandler dbMinTimeHandler,
        IDefaultUserAvatarAsUrlHandler defaultUserAvatarAsUrlHandler
    )
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _dbMinTimeHandler = dbMinTimeHandler;
        _defaultUserAvatarAsUrlHandler = defaultUserAvatarAsUrlHandler;
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
    public async Task<RegisterAsUserResponse> Handle(
        RegisterAsUserRequest request,
        CancellationToken cancellationToken
    )
    {
        // Does user exist by username.
        var isUserFound =
            await _unitOfWork.AuthFeature.RegisterAsUser.Query.IsUserFoundByEmailOrUsernameQueryAsync(
                userEmail: request.Username,
                cancellationToken: cancellationToken
            );

        // User with username already exists.
        if (isUserFound)
        {
            return new() { StatusCode = RegisterAsUserResponseStatusCode.USER_IS_EXISTED };
        }

        //// Is email real.
        //var isEmailReal = await _verifyEmailHandler.IsEmailRealAsync(email: request.Username);

        //// Email is not real.
        //if (!isEmailReal)
        //{
        //    return new()
        //    {
        //        StatusCode = RegisterAsUserResponseStatusCode.USERNAME_IS_NOT_A_REAL_EMAIL
        //    };
        //}

        Domain.Entities.User newUser = new() { Id = Guid.NewGuid(), UserName = request.Username };

        // Is new user password valid.
        var isPasswordValid = await ValidateUserPasswordAsync(
            newUser: newUser,
            newPassword: request.Password
        );

        // Password is not valid.
        if (!isPasswordValid)
        {
            return new()
            {
                StatusCode = RegisterAsUserResponseStatusCode.USER_PASSWORD_IS_NOT_VALID
            };
        }

        // Get user joining status "pending" id.
        var pendingStatus =
            await _unitOfWork.AuthFeature.RegisterAsUser.Query.GetPendingUserJoiningStatusQueryAsync(
                cancellationToken: cancellationToken
            );

        // Completing new user.
        FinishFillingUser(newUser: newUser, userJoiningStatusId: pendingStatus.Id);

        // Create and add user to role.
        var dbResult =
            await _unitOfWork.AuthFeature.RegisterAsUser.Command.CreateAndAddUserToRoleCommandAsync(
                newUser: newUser,
                userPassword: request.Password,
                userRole: "user",
                cancellationToken: cancellationToken
            );

        // Cannot create or add user to role.
        if (!dbResult)
        {
            return new() { StatusCode = RegisterAsUserResponseStatusCode.DATABASE_OPERATION_FAIL };
        }

        // Send account creation confirmation mail to user.
        var mailSendingResult = await SendingConfirmationMailToUserAsync(
            newUser: newUser,
            cancellationToken: cancellationToken
        );

        // Cannot send mail.
        if (!mailSendingResult)
        {
            return new()
            {
                StatusCode = RegisterAsUserResponseStatusCode.SENDING_USER_CONFIRMATION_MAIL_FAIL
            };
        }

        return new() { StatusCode = RegisterAsUserResponseStatusCode.OPERATION_SUCCESS };
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

    /// <summary>
    ///     Finishes filling the user with default
    ///     values for the newly created user.
    /// </summary>
    /// <param name="newUser">
    ///     The newly created user.
    /// </param>
    /// <param name="userJoiningStatusId">
    ///     The status of the user's joining.
    /// </param>
    private void FinishFillingUser(Domain.Entities.User newUser, Guid userJoiningStatusId)
    {
        newUser.Email = newUser.UserName;

        newUser.UserDetail = new()
        {
            Id = newUser.Id,
            UserJoiningStatusId = userJoiningStatusId,
            FirstName = string.Empty,
            LastName = string.Empty,
            UserSkills = string.Empty,
            UserHobbies = string.Empty,
            UserPlatforms = string.Empty,
            Career = string.Empty,
            Workplaces = string.Empty,
            EducationPlaces = string.Empty,
            BirthDay = _dbMinTimeHandler.Get(),
            HomeAddress = string.Empty,
            SelfDescription = string.Empty,
            JoinDate = DateTime.UtcNow,
            AvatarUrl = _defaultUserAvatarAsUrlHandler.Get(),
            MajorId = CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID,
            DepartmentId = CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID,
            PositionId = CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID,
            UpdatedAt = _dbMinTimeHandler.Get(),
            UpdatedBy = CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID,
            RemovedAt = _dbMinTimeHandler.Get(),
            RemovedBy = CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = newUser.Id
        };
    }
    #endregion
}
