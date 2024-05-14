using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Auth.Login;

public interface ILoginCommand
{
    Task<bool> CreateRefreshTokenCommandAsync(
        Entities.RefreshToken newRefreshToken,
        CancellationToken cancellationToken
    );
}
