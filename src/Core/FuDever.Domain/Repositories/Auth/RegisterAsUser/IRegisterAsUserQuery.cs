using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Auth.RegisterAsUser;

public interface IRegisterAsUserQuery
{
    Task<bool> IsUserFoundByEmailOrUsernameQueryAsync(
        string userEmail,
        CancellationToken cancellationToken
    );

    Task<Entities.UserJoiningStatus> GetPendingUserJoiningStatusQueryAsync(
        CancellationToken cancellationToken
    );
}
