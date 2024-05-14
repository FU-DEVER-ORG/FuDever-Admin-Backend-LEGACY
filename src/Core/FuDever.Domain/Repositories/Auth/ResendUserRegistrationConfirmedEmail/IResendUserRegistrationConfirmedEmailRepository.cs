namespace FuDever.Domain.Repositories.Auth.ResendUserRegistrationConfirmedEmail;

public interface IResendUserRegistrationConfirmedEmailRepository
{
    IResendUserRegistrationConfirmedEmailCommand Command { get; }

    IResendUserRegistrationConfirmedEmailQuery Query { get; }
}
