using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Auth.Logout;

public interface ILogoutCommand
{
    Task<bool> RemoveByAccessTokenIdAsync(Guid accessTokenId, CancellationToken cancellationToken);
}
