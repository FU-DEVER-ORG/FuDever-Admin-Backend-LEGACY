using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.FIleObjectStorage;
using FuDever.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Data;

/// <summary>
///     Represent data seeding for database.
/// </summary>
public static class EntityDataSeeding
{
    /// <summary>
    ///     Seed data.
    /// </summary>
    /// <param name="context">
    ///     Database context for interacting with other table.
    /// </param>
    /// <param name="userManager">
    ///     Specific manager for interacting with user table.
    /// </param>
    /// <param name="roleManager">
    ///     Specific manager for interacting with role table.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used for notifying system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if seeding is success. Otherwise, false.
    /// </returns>
    public static async Task<bool> SeedAsync(
        FuDeverContext context,
        UserManager<User> userManager,
        RoleManager<Role> roleManager,
        IDefaultUserAvatarAsUrlHandler defaultUserAvatarAsUrlHandler,
        CancellationToken cancellationToken
    )
    {
        var departments = context.Set<Department>();
        var hobbies = context.Set<Hobby>();
        var majors = context.Set<Major>();
        var platforms = context.Set<Platform>();
        var positions = context.Set<Position>();
        var skills = context.Set<Skill>();
        var userJoiningStatuses = context.Set<UserJoiningStatus>();

        // Is departments table empty.
        var isTableEmpty = await IsTableEmptyAsync(
            departments: departments,
            hobbies: hobbies,
            majors: majors,
            platforms: platforms,
            positions: positions,
            skills: skills,
            userJoiningStatuses: userJoiningStatuses,
            userManager: userManager,
            roleManager: roleManager,
            cancellationToken: cancellationToken
        );

        if (!isTableEmpty)
        {
            return true;
        }

        // Init list of new department.
        var newDepartments = InitNewDepartments();

        // Init list of new hobby.
        var newHobbies = InitNewHobbies();

        // Init list of new major.
        var newMajors = InitNewMajors();

        // Init list of new platform.
        var newPlatforms = InitNewPlatforms();

        // Init list of new position.
        var newPositions = InitNewPositions();

        // Init list of new skill.
        var newSkills = InitNewSkills();

        // Init list of new user joining status.
        var newUserJoiningStatuses = InitNewUserJoiningStatuses();

        // Init list of role.
        var newRoles = InitNewRoles();

        // Init admin.
        var admin = InitAdmin(
            userJoiningStatus: newUserJoiningStatuses.First(predicate: newUserJoiningStatus =>
                newUserJoiningStatus.Type.Equals(value: "Approved")
            ),
            defaultUserAvatarAsUrlHandler: defaultUserAvatarAsUrlHandler
        );

        #region Transaction
        var executedTransactionResult = false;

        await context
            .Database.CreateExecutionStrategy()
            .ExecuteAsync(operation: async () =>
            {
                await using var dbTransaction = await context.Database.BeginTransactionAsync(
                    cancellationToken: cancellationToken
                );

                try
                {
                    await departments.AddRangeAsync(
                        entities: newDepartments,
                        cancellationToken: cancellationToken
                    );

                    await hobbies.AddRangeAsync(
                        entities: newHobbies,
                        cancellationToken: cancellationToken
                    );

                    await majors.AddRangeAsync(
                        entities: newMajors,
                        cancellationToken: cancellationToken
                    );

                    await platforms.AddRangeAsync(
                        entities: newPlatforms,
                        cancellationToken: cancellationToken
                    );

                    await positions.AddRangeAsync(
                        entities: newPositions,
                        cancellationToken: cancellationToken
                    );

                    await skills.AddRangeAsync(
                        entities: newSkills,
                        cancellationToken: cancellationToken
                    );

                    await userJoiningStatuses.AddRangeAsync(
                        entities: newUserJoiningStatuses,
                        cancellationToken: cancellationToken
                    );

                    foreach (var newRole in newRoles)
                    {
                        await roleManager.CreateAsync(role: newRole);
                    }

                    await userManager.CreateAsync(user: admin, password: "Admin123@");

                    await userManager.AddToRoleAsync(user: admin, role: "admin");

                    var emailConfirmationToken =
                        await userManager.GenerateEmailConfirmationTokenAsync(user: admin);

                    await userManager.ConfirmEmailAsync(user: admin, token: emailConfirmationToken);

                    await context.SaveChangesAsync(cancellationToken: cancellationToken);

                    await dbTransaction.CommitAsync(cancellationToken: cancellationToken);

                    executedTransactionResult = true;
                }
                catch
                {
                    await dbTransaction.RollbackAsync(cancellationToken: cancellationToken);
                }
            });
        #endregion

        return executedTransactionResult;
    }

    /// <summary>
    ///    Are tables of database empty.
    /// </summary>
    /// <param name="departments">
    ///     Department dbset for interacting with table.
    /// </param>
    /// <param name="hobbies">
    ///     Hobby dbset for interacting with table.
    /// </param>
    /// <param name="majors">
    ///     Major dbset for interacting with table.
    /// </param>
    /// <param name="platforms">
    ///     Platform dbset for interacting with table.
    /// </param>
    /// <param name="positions">
    ///     Position dbset for interacting with table.
    /// </param>
    /// <param name="skills">
    ///     Skill dbset for interacting with table.
    /// </param>
    /// <param name="userJoiningStatuses">
    ///     User joining status dbset for interacting with table.
    /// </param>
    /// <param name="userManager">
    ///     User manager for interacting with table.
    /// </param>
    /// <param name="roleManager">
    ///     Role manager for interacting with table.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used for notifying system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if table is empty. Otherwise, false.
    /// </returns>
    private static async Task<bool> IsTableEmptyAsync(
        DbSet<Department> departments,
        DbSet<Hobby> hobbies,
        DbSet<Major> majors,
        DbSet<Platform> platforms,
        DbSet<Position> positions,
        DbSet<Skill> skills,
        DbSet<UserJoiningStatus> userJoiningStatuses,
        UserManager<User> userManager,
        RoleManager<Role> roleManager,
        CancellationToken cancellationToken
    )
    {
        // Is departments table empty.
        var isTableNotEmpty = await departments.AnyAsync(cancellationToken: cancellationToken);

        if (isTableNotEmpty)
        {
            return false;
        }

        // Is hobbies table empty.
        isTableNotEmpty = await hobbies.AnyAsync(cancellationToken: cancellationToken);

        if (isTableNotEmpty)
        {
            return false;
        }

        // Is majors table empty.
        isTableNotEmpty = await majors.AnyAsync(cancellationToken: cancellationToken);

        if (isTableNotEmpty)
        {
            return false;
        }

        // Is platforms table empty.
        isTableNotEmpty = await platforms.AnyAsync(cancellationToken: cancellationToken);

        if (isTableNotEmpty)
        {
            return false;
        }

        // Is positions table empty.
        isTableNotEmpty = await positions.AnyAsync(cancellationToken: cancellationToken);

        if (isTableNotEmpty)
        {
            return false;
        }

        // Is skills table empty.
        isTableNotEmpty = await skills.AnyAsync(cancellationToken: cancellationToken);

        if (isTableNotEmpty)
        {
            return false;
        }

        // Is user joining statuses table empty.
        isTableNotEmpty = await userJoiningStatuses.AnyAsync(cancellationToken: cancellationToken);

        if (isTableNotEmpty)
        {
            return false;
        }

        // Is users table empty.
        isTableNotEmpty = await userManager.Users.AnyAsync(cancellationToken: cancellationToken);

        if (isTableNotEmpty)
        {
            return false;
        }

        // Is roles table empty.
        isTableNotEmpty = await roleManager.Roles.AnyAsync(cancellationToken: cancellationToken);

        return !isTableNotEmpty;
    }

    /// <summary>
    ///     Init a list of new department.
    /// </summary>
    /// <returns>
    ///     List of department.
    /// </returns>
    private static List<Department> InitNewDepartments()
    {
        List<string> newDepartmentNames =
        [
            string.Empty,
            "Board of Directors",
            "Academic Board",
            "Administrative Board",
            "Events Board",
            "Media Board"
        ];

        List<Department> newDepartments = [];

        foreach (var newDepartmentName in newDepartmentNames)
        {
            newDepartments.Add(
                item: new()
                {
                    Id = Guid.NewGuid(),
                    Name = newDepartmentName,
                    RemovedAt = Commons.CommonConstant.DbDefaultValue.MIN_DATE_TIME,
                    RemovedBy = Application
                        .Shared
                        .Commons
                        .CommonConstant
                        .App
                        .DEFAULT_ENTITY_ID_AS_GUID
                }
            );
        }

        newDepartments
            .Find(match: newDepartment => newDepartment.Name.Equals(value: newDepartmentNames[0]))
            .Id = Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID;

        return newDepartments;
    }

    /// <summary>
    ///     Init a list of new hobby.
    /// </summary>
    /// <returns>
    ///     List of hobby.
    /// </returns>
    private static List<Hobby> InitNewHobbies()
    {
        List<string> newHobbyNames =
        [
            string.Empty,
            "Volunteering",
            "Cooking",
            "Collecting",
            "Writing",
            "Camping",
            "Sports",
            "Yoga",
            "Photography",
            "Chess",
            "Taekwondo",
            "Birdwatching",
            "DIY Crafts",
            "Games",
            "Baking",
            "Fishing",
            "Coding",
            "Drawing",
            "Playing an Instrument",
            "Painting",
            "Gardening",
            "Hiking",
            "Reading",
            "Dancing",
            "Home Improvement",
            "Surfing",
            "Traveling",
            "Software Engineering"
        ];

        List<Hobby> newHobbies = [];

        foreach (var newHobbyName in newHobbyNames)
        {
            newHobbies.Add(
                item: new()
                {
                    Id = Guid.NewGuid(),
                    Name = newHobbyName,
                    RemovedAt = Commons.CommonConstant.DbDefaultValue.MIN_DATE_TIME,
                    RemovedBy = Application
                        .Shared
                        .Commons
                        .CommonConstant
                        .App
                        .DEFAULT_ENTITY_ID_AS_GUID
                }
            );
        }

        newHobbies.Find(match: newHobby => newHobby.Name.Equals(value: newHobbyNames[0])).Id =
            Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID;

        return newHobbies;
    }

    /// <summary>
    ///     Init a list of new major.
    /// </summary>
    /// <returns>
    ///     List of major.
    /// </returns>
    private static List<Major> InitNewMajors()
    {
        List<string> newMajorNames =
        [
            string.Empty,
            "Software Engineering",
            "Information Security",
            "Digital Art Design",
            "Information System",
            "Artificial Intelligence"
        ];

        List<Major> newMajors = [];

        foreach (var newMajorName in newMajorNames)
        {
            newMajors.Add(
                item: new()
                {
                    Id = Guid.NewGuid(),
                    Name = newMajorName,
                    RemovedAt = Commons.CommonConstant.DbDefaultValue.MIN_DATE_TIME,
                    RemovedBy = Application
                        .Shared
                        .Commons
                        .CommonConstant
                        .App
                        .DEFAULT_ENTITY_ID_AS_GUID
                }
            );
        }

        newMajors.Find(match: newMajor => newMajor.Name.Equals(value: newMajorNames[0])).Id =
            Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID;

        return newMajors;
    }

    /// <summary>
    ///     Init a list of new platform.
    /// </summary>
    /// <returns>
    ///     List of platform.
    /// </returns>
    private static List<Platform> InitNewPlatforms()
    {
        List<string> newPlatformNames =
        [
            string.Empty,
            "LinkedIn",
            "GitHub",
            "Facebook",
            "Youtube",
            "Twitter",
            "Instagram"
        ];

        List<Platform> newPlatforms = [];

        foreach (var newPlatformName in newPlatformNames)
        {
            newPlatforms.Add(
                item: new()
                {
                    Id = Guid.NewGuid(),
                    Name = newPlatformName,
                    RemovedAt = Commons.CommonConstant.DbDefaultValue.MIN_DATE_TIME,
                    RemovedBy = Application
                        .Shared
                        .Commons
                        .CommonConstant
                        .App
                        .DEFAULT_ENTITY_ID_AS_GUID
                }
            );
        }

        newPlatforms
            .Find(match: newPlatform => newPlatform.Name.Equals(value: newPlatformNames[0]))
            .Id = Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID;

        return newPlatforms;
    }

    /// <summary>
    ///     Init a list of new position.
    /// </summary>
    /// <returns>
    ///     List of position.
    /// </returns>
    private static List<Position> InitNewPositions()
    {
        List<string> newPositionNames =
        [
            string.Empty,
            "Club President",
            "Vice Club President",
            "Member",
            "Administrative Department Head",
            "Vice Academic Department Head",
            "Secretary",
            "Media Department Head",
            "Vice Administrative Department Head",
            "Events Department Head",
            "Vice Events Department Head",
            "Academic Department Head"
        ];

        List<Position> newPositions = [];

        foreach (var newPositionName in newPositionNames)
        {
            newPositions.Add(
                item: new()
                {
                    Id = Guid.NewGuid(),
                    Name = newPositionName,
                    RemovedAt = Commons.CommonConstant.DbDefaultValue.MIN_DATE_TIME,
                    RemovedBy = Application
                        .Shared
                        .Commons
                        .CommonConstant
                        .App
                        .DEFAULT_ENTITY_ID_AS_GUID
                }
            );
        }

        newPositions
            .Find(match: newPosition => newPosition.Name.Equals(value: newPositionNames[0]))
            .Id = Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID;

        return newPositions;
    }

    /// <summary>
    ///     Init a list of new skill.
    /// </summary>
    /// <returns>
    ///     List of skill.
    /// </returns>
    private static List<Skill> InitNewSkills()
    {
        List<string> newSkillNames =
        [
            string.Empty,
            "Vue.js",
            "Caching",
            "Flexbox",
            "Docker",
            "Next.js",
            "SQL Server",
            "HTML/CSS",
            "Github",
            "Git",
            "Node.js",
            "Dart",
            "MySQL",
            "Authorization",
            "JavaScript",
            "Web Security",
            "ASP.NET Core",
            "Devops",
            "Python",
            "Apache",
            "PostgreSQL",
            "RESTful API",
            "Express.js",
            "Flask",
            "Bootstrap",
            "Spring Boot",
            "GraphQL",
            "MongoDB",
            "React.js",
            "C#",
            "Agile",
            "Java",
            "C++",
            "Authentication",
            "Django",
            "Angular.js",
            "Ruby",
            "React Native",
            "Typescript",
            "C",
            "SQL",
            "Swift",
            "Flutter",
            "PHP"
        ];

        List<Skill> newSkills = [];

        foreach (var newSkillName in newSkillNames)
        {
            newSkills.Add(
                item: new()
                {
                    Id = Guid.NewGuid(),
                    Name = newSkillName,
                    RemovedAt = Commons.CommonConstant.DbDefaultValue.MIN_DATE_TIME,
                    RemovedBy = Application
                        .Shared
                        .Commons
                        .CommonConstant
                        .App
                        .DEFAULT_ENTITY_ID_AS_GUID
                }
            );
        }

        newSkills.Find(match: newSkill => newSkill.Name.Equals(value: newSkillNames[0])).Id =
            Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID;

        return newSkills;
    }

    /// <summary>
    ///     Init a list of new user joining status.
    /// </summary>
    /// <returns>
    ///     List of user joining status.
    /// </returns>
    private static List<UserJoiningStatus> InitNewUserJoiningStatuses()
    {
        List<string> newUserJoiningStatusTypes =
        [
            string.Empty,
            "Pending",
            "Approved",
            "Expired",
            "Rejected"
        ];

        List<UserJoiningStatus> newUserJoiningStatuses = [];

        foreach (var newUserJoiningStatusType in newUserJoiningStatusTypes)
        {
            newUserJoiningStatuses.Add(
                item: new()
                {
                    Id = Guid.NewGuid(),
                    Type = newUserJoiningStatusType,
                    RemovedAt = Commons.CommonConstant.DbDefaultValue.MIN_DATE_TIME,
                    RemovedBy = Application
                        .Shared
                        .Commons
                        .CommonConstant
                        .App
                        .DEFAULT_ENTITY_ID_AS_GUID
                }
            );
        }

        newUserJoiningStatuses
            .Find(match: newUserJoiningStatus =>
                newUserJoiningStatus.Type.Equals(value: newUserJoiningStatusTypes[0])
            )
            .Id = Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID;

        return newUserJoiningStatuses;
    }

    /// <summary>
    ///     Init a list of new role.
    /// </summary>
    /// <returns>
    ///     List of role.
    /// </returns>
    private static List<Role> InitNewRoles()
    {
        List<string> newRoleNames = ["admin", "user"];

        List<Role> newRoles = [];

        foreach (var newRoleName in newRoleNames)
        {
            newRoles.Add(
                item: new()
                {
                    Id = Guid.NewGuid(),
                    Name = newRoleName,
                    RemovedAt = Commons.CommonConstant.DbDefaultValue.MIN_DATE_TIME,
                    RemovedBy = Application
                        .Shared
                        .Commons
                        .CommonConstant
                        .App
                        .DEFAULT_ENTITY_ID_AS_GUID
                }
            );
        }

        return newRoles;
    }

    /// <summary>
    ///     Init a list of admin.
    /// </summary>
    /// <param name="userJoiningStatus">
    ///     User joining status for admin.
    /// </param>
    /// <returns>
    ///     List of role.
    /// </returns>
    private static User InitAdmin(
        UserJoiningStatus userJoiningStatus,
        IDefaultUserAvatarAsUrlHandler defaultUserAvatarAsUrlHandler
    )
    {
        User admin =
            new()
            {
                Id = Guid.NewGuid(),
                UserName = "ledinhdangkhoa10a9@gmail.com",
                Email = "ledinhdangkhoa10a9@gmail.com",
            };

        admin.UserDetail = new()
        {
            Id = admin.Id,
            UserJoiningStatusId = userJoiningStatus.Id,
            PositionId = Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID,
            MajorId = Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID,
            DepartmentId = Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID,
            FirstName = string.Empty,
            LastName = string.Empty,
            Career = string.Empty,
            Workplaces = string.Empty,
            EducationPlaces = string.Empty,
            UserHobbies = string.Empty,
            UserSkills = string.Empty,
            UserPlatforms = string.Empty,
            BirthDay = Commons.CommonConstant.DbDefaultValue.MIN_DATE_TIME,
            HomeAddress = string.Empty,
            SelfDescription = string.Empty,
            JoinDate = DateTime.UtcNow,
            AvatarUrl = defaultUserAvatarAsUrlHandler.Get(),
            RemovedAt = Commons.CommonConstant.DbDefaultValue.MIN_DATE_TIME,
            RemovedBy = Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID,
            UpdatedAt = Commons.CommonConstant.DbDefaultValue.MIN_DATE_TIME,
            UpdatedBy = Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = admin.Id
        };

        return admin;
    }
}
