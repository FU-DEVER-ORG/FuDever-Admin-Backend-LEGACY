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

namespace FuDever.Domain.UnitOfWorks;

/// <summary>
///     Represent the base unit of work.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    ///     Department repository manager.
    /// </summary>
    IDepartmentFeatureRepository DepartmentFeature { get; }

    /// <summary>
    ///     Hobby repository manager.
    /// </summary>
    IHobbyFeatureRepository HobbyFeature { get; }

    /// <summary>
    ///     Major repository manager.
    /// </summary>
    IMajorFeatureRepository MajorFeature { get; }

    /// <summary>
    ///     Platform repository manager.
    /// </summary>
    IPlatformFeatureRepository PlatformFeature { get; }

    /// <summary>
    ///     Position repository manager.
    /// </summary>
    IPositionFeatureRepository PositionFeature { get; }

    /// <summary>
    ///     Role repository manager.
    /// </summary>
    IRoleFeatureRepository RoleFeature { get; }

    /// <summary>
    ///     Skill repository manager.
    /// </summary>
    ISkillFeatureRepository SkillFeature { get; }

    /// <summary>
    ///     User repository manager.
    /// </summary>
    IUserFeatureRepository UserFeature { get; }

    /// <summary>
    ///     Auth repository manager.
    /// </summary>
    IAuthFeatureRepository AuthFeature { get; }

    /// <summary>
    ///     Admin repository manager.
    /// </summary>
    IAdminFeatureRepository AdminFeature { get; }
}
