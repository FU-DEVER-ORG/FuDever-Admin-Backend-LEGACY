using FuDever.Domain.Specifications.Base;
using FuDever.Domain.Specifications.Entities.Role;
using FuDever.SqlServer.Commons;
using Microsoft.EntityFrameworkCore;

/// <summary>
///     Represent implementation of role by role
///     name specification.
/// </summary>
namespace FuDever.SqlServer.Specifications.Entities.Role;

internal sealed class RoleByNameSpecification
    : BaseSpecification<Domain.Entities.Role>,
        IRoleByNameSpecification
{
    internal RoleByNameSpecification(string roleName, bool isCaseSensitive)
    {
        if (!isCaseSensitive)
        {
            WhereExpression = role => role.Name.Equals(roleName);

            return;
        }

        WhereExpression = role =>
            EF.Functions.Collate(role.Name, CommonConstant.DbCollation.SQL_LATIN1_GENERAL_CP1_CS_AS)
                .Equals(roleName);
    }
}
