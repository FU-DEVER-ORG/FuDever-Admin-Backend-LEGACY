using FuDever.PostgresSql.Data;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Department.RemoveDepartmentTemporarilyByDepartmentId.Others;

internal sealed class RemoveDepartmentTemporarilyByDepartmentIdStateBag
{
    private DbSet<Domain.Entities.RefreshToken> _refreshTokens;
    private DbSet<Domain.Entities.UserDetail> _userDetails;
    private DbSet<Domain.Entities.Department> _departments;

    internal DbSet<Domain.Entities.RefreshToken> RefreshTokens
    {
        get { return _refreshTokens ??= Context.Set<Domain.Entities.RefreshToken>(); }
    }

    internal DbSet<Domain.Entities.UserDetail> UserDetails
    {
        get { return _userDetails ??= Context.Set<Domain.Entities.UserDetail>(); }
    }

    internal DbSet<Domain.Entities.Department> Departments
    {
        get { return _departments ??= Context.Set<Domain.Entities.Department>(); }
    }

    internal FuDeverContext Context { get; }

    public RemoveDepartmentTemporarilyByDepartmentIdStateBag(FuDeverContext context)
    {
        Context = context;
    }
}
