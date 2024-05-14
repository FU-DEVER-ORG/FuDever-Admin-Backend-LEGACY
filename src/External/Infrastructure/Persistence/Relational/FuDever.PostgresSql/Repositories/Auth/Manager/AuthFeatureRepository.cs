using FuDever.Domain.Repositories.Auth.ChangingPassword;
using FuDever.Domain.Repositories.Auth.ConfirmUserRegistrationConfirmedEmail;
using FuDever.Domain.Repositories.Auth.Login;
using FuDever.Domain.Repositories.Auth.Logout;
using FuDever.Domain.Repositories.Auth.Manager;
using FuDever.Domain.Repositories.Auth.RefreshAccessToken;
using FuDever.Domain.Repositories.Auth.RegisterAsUser;
using FuDever.Domain.Repositories.Auth.RequestForgotPassword;
using FuDever.Domain.Repositories.Auth.ResendUserRegistrationConfirmedEmail;
using FuDever.PostgresSql.Data;
using FuDever.PostgresSql.Repositories.Auth.ChangingPassword.Others;
using FuDever.PostgresSql.Repositories.Auth.ConfirmUserRegistrationConfirmedEmail.Others;
using FuDever.PostgresSql.Repositories.Auth.Login.Others;
using FuDever.PostgresSql.Repositories.Auth.Logout.Others;
using FuDever.PostgresSql.Repositories.Auth.RefreshAccessToken.Others;
using FuDever.PostgresSql.Repositories.Auth.RegisterAsUser.Others;
using FuDever.PostgresSql.Repositories.Auth.RequestForgotPassword.Others;
using FuDever.PostgresSql.Repositories.Auth.ResendUserRegistrationConfirmedEmail.Others;
using Microsoft.AspNetCore.Identity;

namespace FuDever.PostgresSql.Repositories.Auth.Manager;

internal sealed class AuthFeatureRepository : IAuthFeatureRepository
{
    private IChangingPasswordRepository _changingPasswordRepository;
    private IConfirmUserRegistrationConfirmedEmailRepository _confirmUserRegistrationConfirmedEmailRepository;
    private ILoginRepository _loginRepository;
    private ILogoutRepository _logoutRepository;
    private IRefreshAccessTokenRepository _refreshAccessTokenRepository;
    private IRegisterAsUserRepository _registerAsUserRepository;
    private IRequestForgotPasswordRepository _requestForgotPasswordRepository;
    private IResendUserRegistrationConfirmedEmailRepository _resendUserRegistrationConfirmedEmailRepository;
    private readonly FuDeverContext _context;
    private readonly UserManager<Domain.Entities.User> _userManager;

    internal AuthFeatureRepository(
        FuDeverContext context,
        UserManager<Domain.Entities.User> userManager
    )
    {
        _context = context;
        _userManager = userManager;
    }

    public IChangingPasswordRepository ChangingPassword
    {
        get
        {
            return _changingPasswordRepository ??= new ChangingPasswordRepository(
                context: _context
            );
        }
    }

    public IConfirmUserRegistrationConfirmedEmailRepository ConfirmUserRegistrationConfirmedEmail
    {
        get
        {
            return _confirmUserRegistrationConfirmedEmailRepository ??=
                new ConfirmUserRegistrationConfirmedEmailRepository(context: _context);
        }
    }

    public ILoginRepository Login
    {
        get { return _loginRepository ??= new LoginRepository(context: _context); }
    }

    public ILogoutRepository Logout
    {
        get { return _logoutRepository ??= new LogoutRepository(context: _context); }
    }

    public IRefreshAccessTokenRepository RefreshAccessToken
    {
        get
        {
            return _refreshAccessTokenRepository ??= new RefreshAccessTokenRepository(
                context: _context
            );
        }
    }

    public IRegisterAsUserRepository RegisterAsUser
    {
        get
        {
            return _registerAsUserRepository ??= new RegisterAsUserRepository(
                context: _context,
                userManager: _userManager
            );
        }
    }

    public IRequestForgotPasswordRepository RequestForgotPassword
    {
        get
        {
            return _requestForgotPasswordRepository ??= new RequestForgotPasswordRepository(
                context: _context
            );
        }
    }

    public IResendUserRegistrationConfirmedEmailRepository ResendUserRegistrationConfirmedEmail
    {
        get
        {
            return _resendUserRegistrationConfirmedEmailRepository ??=
                new ResendUserRegistrationConfirmedEmailRepository(context: _context);
        }
    }
}
