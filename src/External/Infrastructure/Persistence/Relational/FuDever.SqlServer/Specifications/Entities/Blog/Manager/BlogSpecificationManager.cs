using System;
using FuDever.Domain.Specifications.Entities.Blog;
using FuDever.Domain.Specifications.Entities.Blog.Manager;

namespace FuDever.SqlServer.Specifications.Entities.Blog.Manager;

/// <summary>
///     Represent implementation of blog specification manager.
/// </summary>
internal sealed class BlogSpecificationManager : IBlogSpecificationManager
{
    public IBlogByAuthorIdSpecification BlogByAuthorIdSpecification(Guid authorId)
    {
        return new BlogByAuthorIdSpecification(authorId: authorId);
    }
}
