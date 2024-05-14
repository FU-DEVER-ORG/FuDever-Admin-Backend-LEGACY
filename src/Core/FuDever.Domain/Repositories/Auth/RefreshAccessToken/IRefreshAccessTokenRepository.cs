namespace FuDever.Domain.Repositories.Auth.RefreshAccessToken;

public interface IRefreshAccessTokenRepository
{
    IRefreshAccessTokenCommand Command { get; }

    IRefreshAccessTokenQuery Query { get; }
}
