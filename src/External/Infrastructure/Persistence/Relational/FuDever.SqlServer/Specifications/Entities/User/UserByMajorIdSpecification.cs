using System;
using FuDever.Domain.Specifications.Base;
using FuDever.Domain.Specifications.Entities.User;

namespace FuDever.SqlServer.Specifications.Entities.User;

/// <summary>
///     Represent implementation of user by major id
///     specification.
/// </summary>
internal sealed class UserByMajorIdSpecification
    : BaseSpecification<Domain.Entities.User>,
        IUserByMajorIdSpecification
{
    internal UserByMajorIdSpecification(Guid majorId)
    {
        WhereExpression = user => user.MajorId == majorId;
    }
}
