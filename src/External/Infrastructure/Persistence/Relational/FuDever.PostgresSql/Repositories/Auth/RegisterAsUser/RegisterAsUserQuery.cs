using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Entities;
using FuDever.Domain.Repositories.Auth.RegisterAsUser;
using FuDever.PostgresSql.Repositories.Auth.RegisterAsUser.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Auth.RegisterAsUser;

internal sealed class RegisterAsUserQuery : IRegisterAsUserQuery
{
    private readonly RegisterAsUserStateBag _stateBag;

    internal RegisterAsUserQuery(RegisterAsUserStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public Task<UserJoiningStatus> GetPendingUserJoiningStatusQueryAsync(
        CancellationToken cancellationToken
    )
    {
        return _stateBag
            .UserJoiningStatuses.AsNoTracking()
            .Where(predicate: userJoiningStatus => userJoiningStatus.Type.Equals("Pending"))
            .Select(selector: userJoiningStatus => new UserJoiningStatus
            {
                Id = userJoiningStatus.Id
            })
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public Task<bool> IsUserFoundByEmailOrUsernameQueryAsync(
        string userEmail,
        CancellationToken cancellationToken
    )
    {
        userEmail = userEmail.ToUpper();

        return _stateBag.UserManager.Users.AnyAsync(
            predicate: user =>
                user.NormalizedUserName.Equals(userEmail) || user.NormalizedEmail.Equals(userEmail),
            cancellationToken: cancellationToken
        );
    }
}
