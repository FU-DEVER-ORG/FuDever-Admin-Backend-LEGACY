using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.User.GetAllUsers;

public interface IGetAllUsersQuery
{
    Task<IEnumerable<Entities.UserDetail>> GetAllNonTemporarilyRemovedUsersQueryAsync(
        CancellationToken cancellationToken
    );
}
