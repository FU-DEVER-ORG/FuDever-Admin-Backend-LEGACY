using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Department.GetAllDepartmentsByDepartmentName;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Department.GetAllDepartmentsByDepartmentName.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Department.GetAllDepartmentsByDepartmentName;

internal sealed class GetAllDepartmentsByDepartmentNameQuery
    : IGetAllDepartmentsByDepartmentNameQuery
{
    private readonly GetAllDepartmentsByDepartmentNameStateBag _stateBag;

    internal GetAllDepartmentsByDepartmentNameQuery(
        GetAllDepartmentsByDepartmentNameStateBag stateBag
    )
    {
        _stateBag = stateBag;
    }

    public async Task<
        IEnumerable<Domain.Entities.Department>
    > GetAllDepartmentsByDepartmentNameQueryAsync(
        string departmentName,
        CancellationToken cancellationToken
    )
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
                && EF.Functions.Collate(
                        department.Name,
                        CommonConstant.DbCollation.CASE_INSENSITIVE
                    )
                    .Equals(departmentName)
            )
            .Select(department => new Domain.Entities.Department
            {
                Id = department.Id,
                Name = department.Name
            })
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
