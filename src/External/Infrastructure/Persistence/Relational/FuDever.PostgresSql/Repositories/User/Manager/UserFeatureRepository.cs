using FuDever.Domain.Repositories.User.GetAllUsers;
using FuDever.Domain.Repositories.User.Manager;
using FuDever.PostgresSql.Data;
using FuDever.PostgresSql.Repositories.User.GetAllUsers.Others;

namespace FuDever.PostgresSql.Repositories.User.Manager;

internal sealed class UserFeatureRepository : IUserFeatureRepository
{
    private IGetAllUsersRepository _getAllUsersRepository;
    private readonly FuDeverContext _context;

    internal UserFeatureRepository(FuDeverContext context)
    {
        _context = context;
    }

    public IGetAllUsersRepository GetAllUsers
    {
        get { return _getAllUsersRepository ??= new GetAllUsersRepository(context: _context); }
    }
}
