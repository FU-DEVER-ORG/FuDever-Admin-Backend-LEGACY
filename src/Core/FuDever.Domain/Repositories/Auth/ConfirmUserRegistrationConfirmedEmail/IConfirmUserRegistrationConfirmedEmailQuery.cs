using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Auth.ConfirmUserRegistrationConfirmedEmail;

public interface IConfirmUserRegistrationConfirmedEmailQuery
{
    Task<bool> IsUserNotTemporarilyRemovedQueryAsync(
        Guid userId,
        CancellationToken cancellationToken
    );
}
