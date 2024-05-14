namespace FuDever.Domain.Repositories.Auth.Login;

public interface ILoginRepository
{
    ILoginCommand Command { get; }

    ILoginQuery Query { get; }
}
