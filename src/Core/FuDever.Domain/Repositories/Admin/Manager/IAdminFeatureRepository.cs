using FuDever.Domain.Repositories.Admin.ApproveNewUser;
using FuDever.Domain.Repositories.Admin.RejectNewUser;

namespace FuDever.Domain.Repositories.Admin.Manager;

public interface IAdminFeatureRepository
{
    IApproveNewUserRepository ApproveNewUser { get; }

    IRejectNewUserRepository RejectNewUser { get; }
}
