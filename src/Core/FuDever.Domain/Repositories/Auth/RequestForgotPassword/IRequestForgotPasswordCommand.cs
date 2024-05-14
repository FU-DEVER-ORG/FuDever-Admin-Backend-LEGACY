using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Auth.RequestForgotPassword;

public interface IRequestForgotPasswordCommand
{
    Task<bool> AddResetPasswordTokenToDatabase(
        Entities.UserToken newResetPasswordToken,
        CancellationToken cancellationToken
    );
}
