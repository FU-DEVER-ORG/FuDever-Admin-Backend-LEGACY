namespace FuDever.Domain.Repositories.Auth.RequestForgotPassword;

public interface IRequestForgotPasswordRepository
{
    IRequestForgotPasswordCommand Command { get; }

    IRequestForgotPasswordQuery Query { get; }
}
