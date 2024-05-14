using FuDever.Domain.Repositories.Admin.RejectNewUser;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Admin.RejectNewUser.Others;

internal sealed class RejectNewUserRepository : IRejectNewUserRepository
{
    private readonly RejectNewUserStateBag _stateBag;
    private IRejectNewUserQuery _query;
    private IRejectNewUserCommand _command;

    internal RejectNewUserRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IRejectNewUserQuery Query
    {
        get { return _query ??= new RejectNewUserQuery(stateBag: _stateBag); }
    }

    public IRejectNewUserCommand Command
    {
        get { return _command ??= new RejectNewUserCommand(stateBag: _stateBag); }
    }
}
