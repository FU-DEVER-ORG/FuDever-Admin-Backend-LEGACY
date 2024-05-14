using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Admin.ApproveNewUser;

public interface IApproveNewUserCommand
{
    Task<bool> ApproveUserCommandAsync(
        Guid userId,
        Guid approvedUserJoiningStatusId,
        CancellationToken cancellationToken
    );
}
