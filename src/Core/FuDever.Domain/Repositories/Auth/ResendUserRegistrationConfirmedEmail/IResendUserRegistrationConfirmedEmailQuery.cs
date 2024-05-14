using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Auth.ResendUserRegistrationConfirmedEmail;

public interface IResendUserRegistrationConfirmedEmailQuery
{
    Task<bool> IsUserNotTemporarilyRemovedQueryAsync(
        Guid userId,
        CancellationToken cancellationToken
    );
}
