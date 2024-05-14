using FuDever.WebApi.HttpResponseMapper.Auth.ChangingPassword.Others;
using FuDever.WebApi.HttpResponseMapper.Auth.ConfirmUserRegistrationConfirmedEmail.Others;
using FuDever.WebApi.HttpResponseMapper.Auth.Login.Others;
using FuDever.WebApi.HttpResponseMapper.Auth.Logout.Others;
using FuDever.WebApi.HttpResponseMapper.Auth.RefreshAccessToken.Others;
using FuDever.WebApi.HttpResponseMapper.Auth.RegisterAsUser.Others;
using FuDever.WebApi.HttpResponseMapper.Auth.RequestForgotPassword.Others;
using FuDever.WebApi.HttpResponseMapper.Auth.ResendUserRegistrationConfirmedEmail.Others;

namespace FuDever.WebApi.HttpResponseMapper.Auth.Others;

/// <summary>
///     Auth http response manager for managing all auth feature http response mapper
/// </summary>
internal sealed class AuthHttpResponseManager
{
    // Backing fields
    private LoginHttpResponseManager _loginHttpResponseManager;
    private RegisterAsUserHttpResponseManager _registerAsUserHttpResponseManager;
    private ConfirmUserRegistrationConfirmedEmailHttpResponseManager _confirmUserRegistrationConfirmedEmailHttpResponseManager;
    private ResendUserRegistrationConfirmedEmailHttpResponseManager _resendUserRegistrationConfirmedEmailHttpResponseManager;
    private RequestForgotPasswordHttpResponseManager _requestForgotPasswordHttpResponseManager;
    private LogoutHttpResponseManager _logoutHttpResponseManager;
    private RefreshAccessTokenHttpResponseManager _refreshAccessTokenHttpResponseManager;
    private ChangingPasswordHttpResponseManager _changingPasswordHttpResponseManager;

    internal LoginHttpResponseManager Login
    {
        get
        {
            _loginHttpResponseManager ??= new();

            return _loginHttpResponseManager;
        }
    }

    internal RegisterAsUserHttpResponseManager RegisterAsUser
    {
        get
        {
            _registerAsUserHttpResponseManager ??= new();

            return _registerAsUserHttpResponseManager;
        }
    }

    internal ConfirmUserRegistrationConfirmedEmailHttpResponseManager ConfirmUserRegistrationEmail
    {
        get
        {
            _confirmUserRegistrationConfirmedEmailHttpResponseManager ??= new();

            return _confirmUserRegistrationConfirmedEmailHttpResponseManager;
        }
    }

    internal ResendUserRegistrationConfirmedEmailHttpResponseManager ResendUserRegistrationEmail
    {
        get
        {
            _resendUserRegistrationConfirmedEmailHttpResponseManager ??= new();

            return _resendUserRegistrationConfirmedEmailHttpResponseManager;
        }
    }

    internal RequestForgotPasswordHttpResponseManager ForgotPassword
    {
        get
        {
            _requestForgotPasswordHttpResponseManager ??= new();

            return _requestForgotPasswordHttpResponseManager;
        }
    }

    internal LogoutHttpResponseManager Logout
    {
        get
        {
            _logoutHttpResponseManager ??= new();

            return _logoutHttpResponseManager;
        }
    }

    internal RefreshAccessTokenHttpResponseManager RefreshAccessToken
    {
        get
        {
            _refreshAccessTokenHttpResponseManager ??= new();

            return _refreshAccessTokenHttpResponseManager;
        }
    }

    internal ChangingPasswordHttpResponseManager ChangingPassword
    {
        get
        {
            _changingPasswordHttpResponseManager ??= new();

            return _changingPasswordHttpResponseManager;
        }
    }
}
