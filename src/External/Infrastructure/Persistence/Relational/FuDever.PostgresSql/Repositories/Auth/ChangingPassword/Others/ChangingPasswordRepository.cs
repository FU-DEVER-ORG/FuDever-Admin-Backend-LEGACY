using FuDever.Domain.Repositories.Auth.ChangingPassword;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Auth.ChangingPassword.Others;

internal sealed class ChangingPasswordRepository : IChangingPasswordRepository
{
    private readonly ChangingPasswordStateBag _stateBag;
    private IChangingPasswordQuery _query;
    private IChangingPasswordCommand _command;

    internal ChangingPasswordRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IChangingPasswordQuery Query
    {
        get { return _query ??= new ChangingPasswordQuery(stateBag: _stateBag); }
    }

    public IChangingPasswordCommand Command
    {
        get { return _command ??= new ChangingPasswordCommand(stateBag: _stateBag); }
    }
}
