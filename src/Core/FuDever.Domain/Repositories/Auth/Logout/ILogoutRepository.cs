namespace FuDever.Domain.Repositories.Auth.Logout;

public interface ILogoutRepository
{
    ILogoutCommand Command { get; }

    ILogoutQuery Query { get; }
}
