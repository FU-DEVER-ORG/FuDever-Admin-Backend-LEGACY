using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Auth.ChangingPassword;

public interface IChangingPasswordCommand
{
    Task<bool> RemoveUserResetPasswordTokenCommandAsync(
        string resetPasswordToken,
        CancellationToken cancellationToken
    );
}
