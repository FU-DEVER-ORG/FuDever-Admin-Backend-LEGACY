using System;
using FuDever.Domain.Specifications.Entities.Project;
using FuDever.Domain.Specifications.Entities.Project.Manager;

namespace FuDever.SqlServer.Specifications.Entities.Project.Manager;

/// <summary>
///     Represent implementation of project specification manager.
/// </summary>
internal sealed class ProjectSpecificationManager : IProjectSpecificationManager
{
    private IProjectAsNoTrackingSpecification _projectAsNoTrackingSpecification;
    private ISelectFieldsFromProjectSpecification _selectFieldsFromProjectSpecification;

    public IProjectAsNoTrackingSpecification ProjectAsNoTrackingSpecification
    {
        get
        {
            _projectAsNoTrackingSpecification ??= new ProjectAsNoTrackingSpecification();

            return _projectAsNoTrackingSpecification;
        }
    }

    public ISelectFieldsFromProjectSpecification SelectFieldsFromProjectSpecification
    {
        get
        {
            _selectFieldsFromProjectSpecification ??= new SelectFieldsFromProjectSpecification();

            return _selectFieldsFromProjectSpecification;
        }
    }

    public IProjectByTitleSpecification ProjectByTitleSpecification(string projectTitle)
    {
        return new ProjectByTitleSpecification(projectTitle: projectTitle);
    }

    public IProjectByIdSpecification ProjectByIdSpecification(Guid projectId)
    {
        return new ProjectByIdSpecification(projectId: projectId);
    }

    public IProjectByAuthorIdSpecification ProjectByAuthorIdSpecification(Guid authorId)
    {
        return new ProjectByAuthorIdSpecification(authorId: authorId);
    }
}
