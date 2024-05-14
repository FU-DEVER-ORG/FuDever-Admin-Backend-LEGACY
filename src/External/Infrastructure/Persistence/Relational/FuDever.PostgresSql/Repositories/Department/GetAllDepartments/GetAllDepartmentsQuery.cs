using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Department.GetAllDepartments;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Department.GetAllDepartments.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Department.GetAllDepartments;

internal sealed class GetAllDepartmentsQuery : IGetAllDepartmentsQuery
{
    private readonly GetAllDepartmentsStateBag _stateBag;

    internal GetAllDepartmentsQuery(GetAllDepartmentsStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<
        IEnumerable<Domain.Entities.Department>
    > GetAllNonTemporarilyRemovedDepartmentsQueryAsync(CancellationToken cancellationToken)
    {
        // Linq-base
        return await _stateBag
            .Departments.AsNoTracking()
            .Where(predicate: department =>
                department.RemovedAt == CommonConstant.DbDefaultValue.MIN_DATE_TIME
                && department.RemovedBy
                    == Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && department.Id
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
            )
            .Select(department => new Domain.Entities.Department
            {
                Id = department.Id,
                Name = department.Name
            })
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
