using FuDever.PostgresSql.Data;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Department.GetAllDepartments.Others;

internal sealed class GetAllDepartmentsStateBag
{
    private DbSet<Domain.Entities.Department> _departments;

    internal DbSet<Domain.Entities.Department> Departments
    {
        get { return _departments ??= Context.Set<Domain.Entities.Department>(); }
    }

    internal FuDeverContext Context { get; }

    internal GetAllDepartmentsStateBag(FuDeverContext context)
    {
        Context = context;
    }
}
