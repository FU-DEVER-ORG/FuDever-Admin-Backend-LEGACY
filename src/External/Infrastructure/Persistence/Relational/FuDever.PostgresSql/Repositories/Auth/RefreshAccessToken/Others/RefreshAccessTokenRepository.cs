using FuDever.Domain.Repositories.Auth.RefreshAccessToken;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Auth.RefreshAccessToken.Others;

internal sealed class RefreshAccessTokenRepository : IRefreshAccessTokenRepository
{
    private readonly RefreshAccessTokenStateBag _stateBag;
    private IRefreshAccessTokenQuery _query;
    private IRefreshAccessTokenCommand _command;

    internal RefreshAccessTokenRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IRefreshAccessTokenQuery Query
    {
        get { return _query ??= new RefreshAccessTokenQuery(stateBag: _stateBag); }
    }

    public IRefreshAccessTokenCommand Command
    {
        get { return _command ??= new RefreshAccessTokenCommand(stateBag: _stateBag); }
    }
}
