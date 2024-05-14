using FuDever.Domain.Repositories.Auth.Logout;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Auth.Logout.Others;

internal sealed class LogoutRepository : ILogoutRepository
{
    private readonly LogoutStateBag _stateBag;
    private ILogoutQuery _query;
    private ILogoutCommand _command;

    internal LogoutRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public ILogoutQuery Query
    {
        get { return _query ??= new LogoutQuery(stateBag: _stateBag); }
    }

    public ILogoutCommand Command
    {
        get { return _command ??= new LogoutCommand(stateBag: _stateBag); }
    }
}
