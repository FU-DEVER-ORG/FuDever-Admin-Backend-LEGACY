using FuDever.Domain.Repositories.User.GetAllUsers;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.User.GetAllUsers.Others;

internal sealed class GetAllUsersRepository : IGetAllUsersRepository
{
    private readonly GetAllUsersStateBag _stateBag;
    private IGetAllUsersQuery _query;
    private IGetAllUsersCommand _command;

    internal GetAllUsersRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IGetAllUsersQuery Query
    {
        get { return _query ??= new GetAllUsersQuery(stateBag: _stateBag); }
    }

    public IGetAllUsersCommand Command
    {
        get { return _command ??= new GetAllUsersCommand(); }
    }
}
