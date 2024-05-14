using System;
using FuDever.Domain.Specifications.Base;
using FuDever.Domain.Specifications.Entities.Project;

namespace FuDever.SqlServer.Specifications.Entities.Project;

/// <summary>
///     Represent implementation of project by project id specification.
/// </summary>
internal sealed class ProjectByIdSpecification
    : BaseSpecification<Domain.Entities.Project>,
        IProjectByIdSpecification
{
    internal ProjectByIdSpecification(Guid projectId)
    {
        WhereExpression = project => project.Id == projectId;
    }
}
