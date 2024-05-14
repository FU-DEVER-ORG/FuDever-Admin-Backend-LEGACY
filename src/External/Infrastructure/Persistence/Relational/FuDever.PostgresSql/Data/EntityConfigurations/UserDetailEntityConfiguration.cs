using FuDever.Domain.Entities;
using FuDever.PostgresSql.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuDever.PostgresSql.Data.EntityConfigurations;

/// <summary>
///     Represent "UserDetails" table configuration.
/// </summary>
internal sealed class UserDetailEntityConfiguration : IEntityTypeConfiguration<UserDetail>
{
    public void Configure(EntityTypeBuilder<UserDetail> builder)
    {
        const string TableName = "UserDetails";
        const string TableComment = "Contain user detail record.";

        builder.ToTable(
            name: TableName,
            buildAction: table => table.HasComment(comment: TableComment)
        );

        // Primary key configuration.
        builder.HasKey(keyExpression: userDetail => userDetail.Id);

        // UserJoiningStatusId property configuration.
        builder
            .Property(propertyExpression: userDetail => userDetail.UserJoiningStatusId)
            .IsRequired();

        // UpdatedAt property configuration.
        builder
            .Property(propertyExpression: userDetail => userDetail.UpdatedAt)
            .HasColumnType(typeName: CommonConstant.DbDataType.TIMESTAMPTZ)
            .IsRequired();

        // UpdatedBy property configuration.
        builder.Property(propertyExpression: userDetail => userDetail.UpdatedBy).IsRequired();

        // RemovedAt property configuration.
        builder
            .Property(propertyExpression: userDetail => userDetail.RemovedAt)
            .HasColumnType(typeName: CommonConstant.DbDataType.TIMESTAMPTZ)
            .IsRequired();

        // RemovedBy property configuration.
        builder.Property(propertyExpression: userDetail => userDetail.RemovedBy).IsRequired();

        // PositionId property configuration.
        builder.Property(propertyExpression: userDetail => userDetail.PositionId).IsRequired();

        // MajorId property configuration.
        builder.Property(propertyExpression: userDetail => userDetail.MajorId).IsRequired();

        // DepartmentId property configuration.
        builder.Property(propertyExpression: userDetail => userDetail.DepartmentId).IsRequired();

        // FirstName property configuration.
        builder
            .Property(propertyExpression: userDetail => userDetail.FirstName)
            .HasColumnType(typeName: CommonConstant.DbDataType.VarcharGenerator.Get(length: 30))
            .IsRequired();

        // LastName property configuration.
        builder
            .Property(propertyExpression: userDetail => userDetail.LastName)
            .HasColumnType(typeName: CommonConstant.DbDataType.VarcharGenerator.Get(length: 30))
            .IsRequired();

        // Career property configuration.
        builder
            .Property(propertyExpression: userDetail => userDetail.Career)
            .HasColumnType(typeName: CommonConstant.DbDataType.VarcharGenerator.Get(length: 30))
            .IsRequired();

        // Workplaces property configuration.
        builder
            .Property(propertyExpression: userDetail => userDetail.Workplaces)
            .HasColumnType(typeName: CommonConstant.DbDataType.TEXT)
            .IsRequired();

        // UserSkills property configuration.
        builder
            .Property(propertyExpression: userDetail => userDetail.UserSkills)
            .HasColumnType(typeName: CommonConstant.DbDataType.TEXT)
            .IsRequired();

        // UserHobbies property configuration.
        builder
            .Property(propertyExpression: userDetail => userDetail.UserHobbies)
            .HasColumnType(typeName: CommonConstant.DbDataType.TEXT)
            .IsRequired();

        // UserPlatforms property configuration.
        builder
            .Property(propertyExpression: userDetail => userDetail.UserPlatforms)
            .HasColumnType(typeName: CommonConstant.DbDataType.TEXT)
            .IsRequired();

        // EducationPlaces property configuration.
        builder
            .Property(propertyExpression: userDetail => userDetail.EducationPlaces)
            .HasColumnType(typeName: CommonConstant.DbDataType.TEXT)
            .IsRequired();

        // BirthDay property configuration.
        builder
            .Property(propertyExpression: userDetail => userDetail.BirthDay)
            .HasColumnType(typeName: CommonConstant.DbDataType.TIMESTAMPTZ)
            .IsRequired();

        // HomeAddress property configuration.
        builder
            .Property(propertyExpression: userDetail => userDetail.HomeAddress)
            .HasColumnType(typeName: CommonConstant.DbDataType.VarcharGenerator.Get(length: 50))
            .IsRequired();

        // SelfDescription property configuration.
        builder
            .Property(propertyExpression: userDetail => userDetail.SelfDescription)
            .HasColumnType(typeName: CommonConstant.DbDataType.TEXT)
            .IsRequired();

        // JoinDate property configuration.
        builder
            .Property(propertyExpression: userDetail => userDetail.JoinDate)
            .HasColumnType(typeName: CommonConstant.DbDataType.TIMESTAMPTZ)
            .IsRequired();

        // ActivityPoints property configuration.
        builder.Property(propertyExpression: userDetail => userDetail.ActivityPoints).IsRequired();

        // AvatarUrl property configuration.
        builder
            .Property(propertyExpression: userDetail => userDetail.AvatarUrl)
            .HasColumnType(typeName: CommonConstant.DbDataType.TEXT)
            .IsRequired();

        // Table relationship configurations.
        // [UserDetails] - [Blogs] (1 - N).
        builder
            .HasMany(navigationExpression: userDetail => userDetail.Blogs)
            .WithOne(navigationExpression: blog => blog.UserDetail)
            .HasForeignKey(foreignKeyExpression: blog => blog.AuthorId)
            .OnDelete(deleteBehavior: DeleteBehavior.NoAction);

        // [UserDetails] - [Projects] (1 - N).
        builder
            .HasMany(navigationExpression: userDetail => userDetail.Projects)
            .WithOne(navigationExpression: project => project.UserDetail)
            .HasForeignKey(foreignKeyExpression: project => project.AuthorId)
            .OnDelete(deleteBehavior: DeleteBehavior.NoAction);

        // [UserDetails] - [BlogComments] (1 - N).
        builder
            .HasMany(navigationExpression: userDetail => userDetail.BlogComments)
            .WithOne(navigationExpression: blogComment => blogComment.UserDetail)
            .HasForeignKey(foreignKeyExpression: blogComment => blogComment.AuthorId)
            .OnDelete(deleteBehavior: DeleteBehavior.NoAction);
    }
}
