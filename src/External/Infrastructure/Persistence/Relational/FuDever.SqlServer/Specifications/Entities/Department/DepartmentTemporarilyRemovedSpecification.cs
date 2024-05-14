using FuDever.Domain.Specifications.Base;
using FuDever.Domain.Specifications.Entities.Department;
using FuDever.SqlServer.Commons;

namespace FuDever.SqlServer.Specifications.Entities.Department;

/// <summary>
///     Represent implementation of department temporarily removed specification.
/// </summary>
internal sealed class DepartmentTemporarilyRemovedSpecification
    : BaseSpecification<Domain.Entities.Department>,
        IDepartmentTemporarilyRemovedSpecification
{
    internal DepartmentTemporarilyRemovedSpecification()
    {
        var minDateTimeInDatabase = CommonConstant.DbDefaultValue.MIN_DATE_TIME;

        WhereExpression = department =>
            department.RemovedBy != Application.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
            && department.RemovedAt != minDateTimeInDatabase;
    }
}
