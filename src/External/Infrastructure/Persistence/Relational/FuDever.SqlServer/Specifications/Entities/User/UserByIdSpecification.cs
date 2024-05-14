using System;
using FuDever.Domain.Specifications.Base;
using FuDever.Domain.Specifications.Entities.User;

namespace FuDever.SqlServer.Specifications.Entities.User;

/// <summary>
///     Represent implementation of user by user id
///     specification.
/// </summary>
internal sealed class UserByIdSpecification
    : BaseSpecification<Domain.Entities.User>,
        IUserByIdSpecification
{
    internal UserByIdSpecification(Guid userId)
    {
        WhereExpression = user => user.Id == userId;
    }
}
