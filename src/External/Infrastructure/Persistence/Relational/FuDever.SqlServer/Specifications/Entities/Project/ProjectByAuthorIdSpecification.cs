using System;
using FuDever.Domain.Specifications.Base;
using FuDever.Domain.Specifications.Entities.Project;

namespace FuDever.SqlServer.Specifications.Entities.Project;

/// <summary>
///     Represent implementation of project by project author id specification.
/// </summary>
internal sealed class ProjectByAuthorIdSpecification
    : BaseSpecification<Domain.Entities.Project>,
        IProjectByAuthorIdSpecification
{
    internal ProjectByAuthorIdSpecification(Guid authorId)
    {
        WhereExpression = project => project.AuthorId == authorId;
    }
}
