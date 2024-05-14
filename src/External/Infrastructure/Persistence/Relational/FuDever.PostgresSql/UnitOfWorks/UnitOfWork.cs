using FuDever.Domain.Repositories.Admin.Manager;
using FuDever.Domain.Repositories.Auth.Manager;
using FuDever.Domain.Repositories.Department.Manager;
using FuDever.Domain.Repositories.Hobby.Manager;
using FuDever.Domain.Repositories.Major.Manager;
using FuDever.Domain.Repositories.Platform.Manager;
using FuDever.Domain.Repositories.Position.Manager;
using FuDever.Domain.Repositories.Role.Manager;
using FuDever.Domain.Repositories.Skill.Manager;
using FuDever.Domain.Repositories.User.Manager;
using FuDever.Domain.UnitOfWorks;
using FuDever.PostgresSql.Data;
using FuDever.PostgresSql.Repositories.Admin.Manager;
using FuDever.PostgresSql.Repositories.Auth.Manager;
using FuDever.PostgresSql.Repositories.Department.Manager;
using FuDever.PostgresSql.Repositories.Hobby.Manager;
using FuDever.PostgresSql.Repositories.Major.Manager;
using FuDever.PostgresSql.Repositories.Platform.Manager;
using FuDever.PostgresSql.Repositories.Position.Manager;
using FuDever.PostgresSql.Repositories.Role.Manager;
using FuDever.PostgresSql.Repositories.Skill.Manager;
using FuDever.PostgresSql.Repositories.User.Manager;
using Microsoft.AspNetCore.Identity;

namespace FuDever.PostgresSql.UnitOfWorks;

/// <summary>
///     Implementation of unit of work.
/// </summary>
internal sealed class UnitOfWork : IUnitOfWork
{
    private IDepartmentFeatureRepository _departmentFeatureRepository;
    private IHobbyFeatureRepository _hobbyFeatureRepository;
    private IMajorFeatureRepository _majorFeatureRepository;
    private PlatformFeatureRepository _platformFeatureRepository;
    private IPositionFeatureRepository _positionFeatureRepository;
    private IRoleFeatureRepository _roleFeatureRepository;
    private ISkillFeatureRepository _skillFeatureRepository;
    private IUserFeatureRepository _userFeatureRepository;
    private IAuthFeatureRepository _authFeatureRepository;
    private IAdminFeatureRepository _adminFeatureRepository;
    private readonly FuDeverContext _context;
    private readonly RoleManager<Domain.Entities.Role> _roleManager;
    private readonly UserManager<Domain.Entities.User> _userManager;

    public UnitOfWork(
        FuDeverContext context,
        RoleManager<Domain.Entities.Role> roleManager,
        UserManager<Domain.Entities.User> userManager
    )
    {
        _context = context;
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public IDepartmentFeatureRepository DepartmentFeature
    {
        get
        {
            return _departmentFeatureRepository ??= new DepartmentFeatureRepository(
                context: _context
            );
        }
    }

    public IHobbyFeatureRepository HobbyFeature
    {
        get { return _hobbyFeatureRepository ??= new HobbyFeatureRepository(context: _context); }
    }

    public IMajorFeatureRepository MajorFeature
    {
        get { return _majorFeatureRepository ??= new MajorFeatureRepository(context: _context); }
    }

    public IPlatformFeatureRepository PlatformFeature
    {
        get
        {
            return _platformFeatureRepository ??= new PlatformFeatureRepository(context: _context);
        }
    }

    public IPositionFeatureRepository PositionFeature
    {
        get
        {
            return _positionFeatureRepository ??= new PositionFeatureRepository(context: _context);
        }
    }

    public IRoleFeatureRepository RoleFeature
    {
        get
        {
            return _roleFeatureRepository ??= new RoleFeatureRepository(
                context: _context,
                roleManager: _roleManager
            );
        }
    }

    public ISkillFeatureRepository SkillFeature
    {
        get { return _skillFeatureRepository ??= new SkillFeatureRepository(context: _context); }
    }

    public IUserFeatureRepository UserFeature
    {
        get { return _userFeatureRepository ??= new UserFeatureRepository(context: _context); }
    }

    public IAuthFeatureRepository AuthFeature
    {
        get
        {
            return _authFeatureRepository ??= new AuthFeatureRepository(
                context: _context,
                userManager: _userManager
            );
        }
    }

    public IAdminFeatureRepository AdminFeature
    {
        get { return _adminFeatureRepository ??= new AdminFeatureRepository(context: _context); }
    }
}
