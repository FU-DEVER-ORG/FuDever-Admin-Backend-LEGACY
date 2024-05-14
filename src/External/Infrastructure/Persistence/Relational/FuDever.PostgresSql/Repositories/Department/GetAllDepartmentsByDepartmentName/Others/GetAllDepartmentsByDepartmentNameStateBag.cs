using FuDever.PostgresSql.Data;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Department.GetAllDepartmentsByDepartmentName.Others;

internal sealed class GetAllDepartmentsByDepartmentNameStateBag
{
    private DbSet<Domain.Entities.Department> _departments;

    internal DbSet<Domain.Entities.Department> Departments
    {
        get { return _departments ??= Context.Set<Domain.Entities.Department>(); }
    }

    internal FuDeverContext Context { get; }

    internal GetAllDepartmentsByDepartmentNameStateBag(FuDeverContext context)
    {
        Context = context;
    }
}
