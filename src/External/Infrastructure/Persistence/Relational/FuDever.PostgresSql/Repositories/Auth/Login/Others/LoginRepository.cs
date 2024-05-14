using FuDever.Domain.Repositories.Auth.Login;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Auth.Login.Others;

internal sealed class LoginRepository : ILoginRepository
{
    private readonly LoginStateBag _stateBag;
    private ILoginQuery _query;
    private ILoginCommand _command;

    internal LoginRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public ILoginQuery Query
    {
        get { return _query ??= new LoginQuery(stateBag: _stateBag); }
    }

    public ILoginCommand Command
    {
        get { return _command ??= new LoginCommand(stateBag: _stateBag); }
    }
}
