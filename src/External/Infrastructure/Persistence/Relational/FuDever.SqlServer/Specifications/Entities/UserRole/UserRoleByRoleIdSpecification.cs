using System;
using FuDever.Domain.Specifications.Base;
using FuDever.Domain.Specifications.Entities.UserRole;

namespace FuDever.SqlServer.Specifications.Entities.UserRole;

/// <summary>
///     Represent implementation of user role by role
///     id specification.
/// </summary>
internal sealed class UserRoleByRoleIdSpecification
    : BaseSpecification<Domain.Entities.UserRole>,
        IUserRoleByRoleIdSpecification
{
    public UserRoleByRoleIdSpecification(Guid roleId)
    {
        WhereExpression = userRole => userRole.RoleId == roleId;
    }
}
