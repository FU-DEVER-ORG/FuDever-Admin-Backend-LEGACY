using FuDever.Domain.Repositories.Admin.ApproveNewUser;
using FuDever.Domain.Repositories.Admin.Manager;
using FuDever.Domain.Repositories.Admin.RejectNewUser;
using FuDever.PostgresSql.Data;
using FuDever.PostgresSql.Repositories.Admin.ApproveNewUser.Others;
using FuDever.PostgresSql.Repositories.Admin.RejectNewUser.Others;

namespace FuDever.PostgresSql.Repositories.Admin.Manager;

internal sealed class AdminFeatureRepository : IAdminFeatureRepository
{
    private IApproveNewUserRepository _approveNewUserRepository;
    private IRejectNewUserRepository _rejectNewUserRepository;
    private readonly FuDeverContext _context;

    internal AdminFeatureRepository(FuDeverContext context)
    {
        _context = context;
    }

    public IApproveNewUserRepository ApproveNewUser
    {
        get
        {
            return _approveNewUserRepository ??= new ApproveNewUserRepository(context: _context);
        }
    }

    public IRejectNewUserRepository RejectNewUser
    {
        get { return _rejectNewUserRepository ??= new RejectNewUserRepository(context: _context); }
    }
}
