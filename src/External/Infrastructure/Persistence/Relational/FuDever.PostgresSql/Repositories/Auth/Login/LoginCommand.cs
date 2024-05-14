using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Entities;
using FuDever.Domain.Repositories.Auth.Login;
using FuDever.PostgresSql.Repositories.Auth.Login.Others;

namespace FuDever.PostgresSql.Repositories.Auth.Login;

internal sealed class LoginCommand : ILoginCommand
{
    private readonly LoginStateBag _stateBag;

    internal LoginCommand(LoginStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> CreateRefreshTokenCommandAsync(
        RefreshToken newRefreshToken,
        CancellationToken cancellationToken
    )
    {
        try
        {
            await _stateBag.Context.AddAsync(
                entity: newRefreshToken,
                cancellationToken: cancellationToken
            );

            await _stateBag.Context.SaveChangesAsync(cancellationToken: cancellationToken);
        }
        catch
        {
            return false;
        }

        return true;
    }
}
