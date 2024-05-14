using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Auth.RequestForgotPassword;

public interface IRequestForgotPasswordQuery
{
    Task<bool> IsUserNotTemporarilyRemovedQueryAsync(
        Guid userId,
        CancellationToken cancellationToken
    );
}
