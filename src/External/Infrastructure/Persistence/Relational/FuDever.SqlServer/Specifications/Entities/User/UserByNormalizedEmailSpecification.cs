using FuDever.Domain.Specifications.Base;
using FuDever.Domain.Specifications.Entities.User;

namespace FuDever.SqlServer.Specifications.Entities.User;

/// <summary>
///     Implementation of user by normalized email specification.
/// </summary>
internal sealed class UserByNormalizedEmailSpecification
    : BaseSpecification<Domain.Entities.User>,
        IUserByNormalizedEmailSpecification
{
    public UserByNormalizedEmailSpecification(string userEmail)
    {
        userEmail = userEmail.ToUpper();

        WhereExpression = user => user.NormalizedEmail.Equals(userEmail);
    }
}
