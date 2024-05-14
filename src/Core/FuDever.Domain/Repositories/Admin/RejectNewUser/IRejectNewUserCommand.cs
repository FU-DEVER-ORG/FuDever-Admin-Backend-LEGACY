using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Admin.RejectNewUser;

public interface IRejectNewUserCommand
{
    Task<bool> RejectUserCommandAsync(
        Guid userId,
        Guid rejectedUserJoiningStatusId,
        CancellationToken cancellationToken
    );
}
