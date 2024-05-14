using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Auth.RegisterAsUser;

public interface IRegisterAsUserCommand
{
    Task<bool> CreateAndAddUserToRoleCommandAsync(
        Domain.Entities.User newUser,
        string userPassword,
        string userRole,
        CancellationToken cancellationToken
    );
}
