using FuDever.Domain.EntityBuilders.UserPlatform;
using FuDever.Domain.Specifications.Base;
using FuDever.Domain.Specifications.Entities.UserPlatform;

namespace FuDever.SqlServer.Specifications.Entities.UserPlatform;

/// <summary>
///     Represent implementation of select fields from the "UserPlatforms"
///     table specification.
/// </summary>
internal sealed class SelectFieldsFromUserPlatformSpecification
    : BaseSpecification<Domain.Entities.UserPlatform>,
        ISelectFieldsFromUserPlatformSpecification
{
    public ISelectFieldsFromUserPlatformSpecification Ver1()
    {
        UserPlatformForDatabaseRetrievingBuilder builder = new();

        SelectExpression = userPlatform => builder.WithUserId(userPlatform.UserId).Complete();

        return this;
    }
}
