using FuDever.Domain.Specifications.Base;
using FuDever.Domain.Specifications.Entities.User;

namespace FuDever.SqlServer.Specifications.Entities.User;

/// <summary>
///     Implementation of user by normalized username specification.
/// </summary>
internal sealed class UserByNormalizedUsernameSpecification
    : BaseSpecification<Domain.Entities.User>,
        IUserByNormalizedUsernameSpecification
{
    public UserByNormalizedUsernameSpecification(string username)
    {
        username = username.ToUpper();

        WhereExpression = user => user.NormalizedUserName.Equals(username);
    }
}
