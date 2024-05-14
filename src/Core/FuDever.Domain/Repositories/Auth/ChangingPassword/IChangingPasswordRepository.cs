namespace FuDever.Domain.Repositories.Auth.ChangingPassword;

public interface IChangingPasswordRepository
{
    IChangingPasswordCommand Command { get; }

    IChangingPasswordQuery Query { get; }
}
