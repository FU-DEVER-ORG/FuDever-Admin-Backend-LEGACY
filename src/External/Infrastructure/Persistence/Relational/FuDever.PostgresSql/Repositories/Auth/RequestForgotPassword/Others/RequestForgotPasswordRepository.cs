using FuDever.Domain.Repositories.Auth.RequestForgotPassword;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Auth.RequestForgotPassword.Others;

internal sealed class RequestForgotPasswordRepository : IRequestForgotPasswordRepository
{
    private readonly RequestForgotPasswordStateBag _stateBag;
    private IRequestForgotPasswordQuery _query;
    private IRequestForgotPasswordCommand _command;

    internal RequestForgotPasswordRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IRequestForgotPasswordQuery Query
    {
        get { return _query ??= new RequestForgotPasswordQuery(stateBag: _stateBag); }
    }

    public IRequestForgotPasswordCommand Command
    {
        get { return _command ??= new RequestForgotPasswordCommand(stateBag: _stateBag); }
    }
}
