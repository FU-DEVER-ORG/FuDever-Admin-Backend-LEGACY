using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Auth.ChangingPassword;
using FuDever.Application.Features.Auth.ConfirmUserRegistrationConfirmedEmail;
using FuDever.Application.Features.Auth.Login;
using FuDever.Application.Features.Auth.Logout;
using FuDever.Application.Features.Auth.RefreshAccessToken;
using FuDever.Application.Features.Auth.RegisterAsUser;
using FuDever.Application.Features.Auth.RequestForgotPassword;
using FuDever.Application.Features.Auth.ResendUserRegistrationConfirmedEmail;
using FuDever.WebApi.DTOs.Auth.Incomings;
using FuDever.WebApi.HttpResponseMapper.Others;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FuDever.WebApi.Controllers;

[Consumes(contentType: MediaTypeNames.Application.Json)]
[Produces(contentType: MediaTypeNames.Application.Json)]
[ApiController]
[Route(template: "api/[controller]")]
public sealed class AuthController : ControllerBase
{
    private readonly ISender _sender;
    private readonly HttpResponseMapperManager _httpResponseMapperManager;

    public AuthController(ISender sender, HttpResponseMapperManager httpResponseMapperManager)
    {
        _sender = sender;
        _httpResponseMapperManager = httpResponseMapperManager;
    }

    /// <summary>
    ///     Endpoint for user login.
    /// </summary>
    /// <param name="dto">
    ///     Class contains user credentials.
    /// </param>
    /// <param name="cancellationToken">
    ///     Automatic initialized token for aborting current operation.
    /// </param>
    ///     App code and some login information.
    /// <remarks>
    /// Sample request:
    ///
    ///     POST api/Auth/sign-in
    ///     {
    ///         "email": "string",
    ///         "password": "string",
    ///         "rememberMe": true
    ///     }
    ///
    /// </remarks>
    [HttpPost(template: "sign-in")]
    public async Task<IActionResult> LoginAsync(
        [FromBody] LoginUserDto dto,
        CancellationToken cancellationToken
    )
    {
        // Login request init.
        LoginRequest featureRequest =
            new()
            {
                Username = dto.Username,
                Password = dto.Password,
                RememberMe = dto.RememberMe
            };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Auth.Login.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Endpoint for user register.
    /// </summary>
    /// <param name="dto">
    ///     Class contains user register credentials.
    /// </param>
    /// <param name="cancellationToken">
    ///     Automatic initialized token for aborting current operation.
    /// </param>
    /// <returns>
    ///     App code.
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST api/Auth/sign-up
    ///     {
    ///         "email": "string",
    ///         "password": "string"
    ///     }
    ///
    /// </remarks>
    [HttpPost(template: "sign-up")]
    public async Task<IActionResult> RegisterAsync(
        [FromBody] RegisterAsUserDto dto,
        CancellationToken cancellationToken
    )
    {
        // Register as user request init.
        RegisterAsUserRequest featureRequest =
            new() { Username = dto.Username, Password = dto.Password };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Auth.RegisterAsUser.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Endpoint for confirm user registration confirmed email
    /// </summary>
    /// <param name="base64UserRegistrationConfirmedEmailToken">
    ///     A token value that will be used for user registration
    ///     email confirmation
    /// </param>
    /// <param name="cancellationToken">
    ///     Automatic initialized token for aborting current operation.
    /// </param>
    /// <returns>
    ///     App code.
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET api/Auth/sign-up/confirm-email?
    ///         token={base64UserRegistrationConfirmedEmailToken}
    ///
    /// </remarks>
    [HttpGet(template: "sign-up/confirm-email")]
    public async Task<IActionResult> ConfirmUserRegistrationConfirmedEmailAsync(
        [FromQuery(Name = "token")] [Required] string base64UserRegistrationConfirmedEmailToken,
        CancellationToken cancellationToken
    )
    {
        // Confirm user registration confirmed email init.
        ConfirmUserRegistrationConfirmedEmailRequest featureRequest =
            new()
            {
                UserRegistrationEmailConfirmedTokenAsBase64 =
                    base64UserRegistrationConfirmedEmailToken,
                CacheExpiredTime = 60
            };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Auth.ConfirmUserRegistrationEmail.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        if (!Equals(objA: apiResponse.Body, objB: default))
        {
            return Content(
                content: apiResponse.Body.ToString(),
                contentType: MediaTypeNames.Text.Html
            );
        }

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Endpoint for resend user
    ///     registration confirmed email purpose
    /// </summary>
    /// <param name="dto">
    ///     Class contains user credentials.
    /// </param>
    /// <param name="cancellationToken">
    ///     Automatic initialized token for aborting current operation.
    /// </param>
    /// <returns>
    ///     App code.
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST api/Auth/sign-up/resend-confirmed-email
    ///     {
    ///         "username": "string"
    ///     }
    ///
    /// </remarks>
    [HttpPost(template: "sign-up/resend-confirmed-email")]
    public async Task<IActionResult> ResendUserRegistrationConfirmedEmailAsync(
        [FromBody] ResendUserRegistrationConfirmedEmailDto dto,
        CancellationToken cancellationToken
    )
    {
        // Resend user registration confirmed email request init.
        ResendUserRegistrationConfirmedEmailRequest featureRequest =
            new() { Username = dto.Username, CacheExpiredTime = 60 };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Auth.ResendUserRegistrationEmail.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Endpoint for user to forgot password.
    /// </summary>
    /// <param name="dto">
    ///     Class contains user credentials.
    /// </param>
    /// <param name="cancellationToken">
    ///     Automatic initialized token for aborting current operation.
    /// </param>
    /// <returns>
    ///     App code.
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET api/Auth/forgot-password
    ///     {
    ///         "username": "string"
    ///     }
    ///
    /// </remarks>
    [HttpPost(template: "forgot-password")]
    public async Task<IActionResult> RequestForgotPasswordAsync(
        [FromBody] ForgotPasswordDto dto,
        CancellationToken cancellationToken
    )
    {
        // Forgot password request init.
        RequestForgotPasswordRequest featureRequest = new() { Username = dto.Username };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Auth.ForgotPassword.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Endpoint for user to changing password.
    /// </summary>
    /// <param name="dto">
    ///     Class contains user credentials.
    /// </param>
    /// <param name="cancellationToken">
    ///     Automatic initialized token for aborting current operation.
    /// </param>
    /// <returns>
    ///     App code.
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     PATCH api/Auth/changing-password
    ///     {
    ///         "newPassword": "string",
    ///         "resetPasswordToken" "string"
    ///     }
    ///
    /// </remarks>
    [HttpPatch(template: "change-password")]
    public async Task<IActionResult> ChangingPasswordAsync(
        [FromBody] ChangingPasswordDto dto,
        CancellationToken cancellationToken
    )
    {
        // Changing password request init.
        ChangingPasswordRequest featureRequest =
            new() { NewPassword = dto.NewPassword, ResetPasswordToken = dto.ResetPasswordToken };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Auth.ChangingPassword.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Endpoint for user log out
    /// </summary>
    /// <param name="cancellationToken">
    ///     Automatic initialized token for aborting current operation.
    /// </param>
    /// <returns>
    ///     App code.
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE api/Auth/sign-out
    ///
    /// </remarks>
    [HttpDelete(template: "sign-out")]
    public async Task<IActionResult> LogoutAsync(CancellationToken cancellationToken)
    {
        // Logout request init.
        LogoutRequest featureRequest = new() { };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Auth.Logout.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Endpoint for refresh curent access token and
    ///     generate new access token and refresh token.
    /// </summary>
    /// <param name="dto">
    ///     A class contains refresh token value that will be used to generate
    ///     new access token and refresh token.
    /// </param>
    /// <param name="cancellationToken">
    ///     Automatic initialized token for aborting current operation.
    /// </param>
    /// <returns>
    ///     App code.
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     PATCH api/Auth/refresh-access-token
    ///     {
    ///         "refreshToken": "string"
    ///     }
    ///
    /// </remarks>
    [HttpPatch(template: "refresh-access-token")]
    public async Task<IActionResult> RefreshAccessTokenAsync(
        [FromBody] RefreshAccessTokenDto dto,
        CancellationToken cancellationToken
    )
    {
        // Refresh access token request init.
        RefreshAccessTokenRequest featureRequest = new() { RefreshToken = dto.RefreshToken };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Auth.RefreshAccessToken.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }
}
