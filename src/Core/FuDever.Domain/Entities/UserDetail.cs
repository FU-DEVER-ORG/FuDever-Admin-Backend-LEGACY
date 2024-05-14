using System;
using System.Collections.Generic;
using FuDever.Domain.Entities.Base;

namespace FuDever.Domain.Entities;

public class UserDetail : IBaseEntity, ICreatedEntity, IUpdatedEntity, ITemporarilyRemovedEntity
{
    public Guid Id { get; set; }

    public Guid UserJoiningStatusId { get; set; }

    public Guid PositionId { get; set; }

    public Guid MajorId { get; set; }

    public Guid DepartmentId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Career { get; set; }

    public string Workplaces { get; set; }

    public string UserSkills { get; set; }

    public string UserHobbies { get; set; }

    public string UserPlatforms { get; set; }

    public string EducationPlaces { get; set; }

    public DateTime BirthDay { get; set; }

    public string HomeAddress { get; set; }

    public string SelfDescription { get; set; }

    public DateTime JoinDate { get; set; }

    public short ActivityPoints { get; set; }

    public string AvatarUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid UpdatedBy { get; set; }

    public DateTime RemovedAt { get; set; }

    public Guid RemovedBy { get; set; }

    // Navigation properties.
    public Position Position { get; set; }

    public Major Major { get; set; }

    public Department Department { get; set; }

    public UserJoiningStatus UserJoiningStatus { get; set; }

    public User User { get; set; }

    // Navigation collections.
    public IEnumerable<Blog> Blogs { get; set; }

    public IEnumerable<Project> Projects { get; set; }

    public IEnumerable<BlogComment> BlogComments { get; set; }

    public static class Metadata
    {
        public static class ActitvityPoints
        {
            public const int MinValue = 0;

            public const int MaxValue = 100;
        }
    }
}
