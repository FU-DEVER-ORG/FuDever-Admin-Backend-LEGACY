using FuDever.Domain.Repositories.Auth.ChangingPassword;
using FuDever.Domain.Repositories.Auth.ConfirmUserRegistrationConfirmedEmail;
using FuDever.Domain.Repositories.Auth.Login;
using FuDever.Domain.Repositories.Auth.Logout;
using FuDever.Domain.Repositories.Auth.RefreshAccessToken;
using FuDever.Domain.Repositories.Auth.RegisterAsUser;
using FuDever.Domain.Repositories.Auth.RequestForgotPassword;
using FuDever.Domain.Repositories.Auth.ResendUserRegistrationConfirmedEmail;

namespace FuDever.Domain.Repositories.Auth.Manager;

public interface IAuthFeatureRepository
{
    IChangingPasswordRepository ChangingPassword { get; }

    IConfirmUserRegistrationConfirmedEmailRepository ConfirmUserRegistrationConfirmedEmail { get; }

    ILoginRepository Login { get; }

    ILogoutRepository Logout { get; }

    IRefreshAccessTokenRepository RefreshAccessToken { get; }

    IRegisterAsUserRepository RegisterAsUser { get; }

    IRequestForgotPasswordRepository RequestForgotPassword { get; }

    IResendUserRegistrationConfirmedEmailRepository ResendUserRegistrationConfirmedEmail { get; }
}
