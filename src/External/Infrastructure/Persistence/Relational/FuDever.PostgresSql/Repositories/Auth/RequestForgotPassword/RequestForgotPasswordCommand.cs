using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Auth.RequestForgotPassword;
using FuDever.PostgresSql.Repositories.Auth.RequestForgotPassword.Others;

namespace FuDever.PostgresSql.Repositories.Auth.RequestForgotPassword;

internal sealed class RequestForgotPasswordCommand : IRequestForgotPasswordCommand
{
    private readonly RequestForgotPasswordStateBag _stateBag;

    internal RequestForgotPasswordCommand(RequestForgotPasswordStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> AddResetPasswordTokenToDatabase(
        Domain.Entities.UserToken newResetPasswordToken,
        CancellationToken cancellationToken
    )
    {
        try
        {
            await _stateBag.Context.AddAsync(
                entity: newResetPasswordToken,
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
