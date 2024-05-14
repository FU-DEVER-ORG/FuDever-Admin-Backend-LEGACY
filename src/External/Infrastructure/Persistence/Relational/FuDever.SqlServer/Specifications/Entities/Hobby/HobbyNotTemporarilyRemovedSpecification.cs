using FuDever.Domain.Specifications.Base;
using FuDever.Domain.Specifications.Entities.Hobby;
using FuDever.SqlServer.Commons;

namespace FuDever.SqlServer.Specifications.Entities.Hobby;

/// <summary>
///     Represent implementation of hobby not temporarily removed specification.
/// </summary>
internal sealed class HobbyNotTemporarilyRemovedSpecification
    : BaseSpecification<Domain.Entities.Hobby>,
        IHobbyNotTemporarilyRemovedSpecification
{
    internal HobbyNotTemporarilyRemovedSpecification()
    {
        var minDateTimeInDatabase = CommonConstant.DbDefaultValue.MIN_DATE_TIME;

        WhereExpression = hobby =>
            hobby.RemovedBy == Application.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
            && hobby.RemovedAt == minDateTimeInDatabase;
    }
}
