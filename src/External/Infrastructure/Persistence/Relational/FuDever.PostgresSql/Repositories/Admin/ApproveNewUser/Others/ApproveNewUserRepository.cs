using FuDever.Domain.Repositories.Admin.ApproveNewUser;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Admin.ApproveNewUser.Others;

internal sealed class ApproveNewUserRepository : IApproveNewUserRepository
{
    private readonly ApproveNewUserStateBag _stateBag;
    private IApproveNewUserQuery _query;
    private IApproveNewUserCommand _command;

    internal ApproveNewUserRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IApproveNewUserQuery Query
    {
        get { return _query ??= new ApproveNewUserQuery(stateBag: _stateBag); }
    }

    public IApproveNewUserCommand Command
    {
        get { return _command ??= new ApproveNewUserCommand(stateBag: _stateBag); }
    }
}
