namespace FuDever.Domain.Repositories.Auth.ConfirmUserRegistrationConfirmedEmail;

public interface IConfirmUserRegistrationConfirmedEmailRepository
{
    IConfirmUserRegistrationConfirmedEmailCommand Command { get; }

    IConfirmUserRegistrationConfirmedEmailQuery Query { get; }
}
