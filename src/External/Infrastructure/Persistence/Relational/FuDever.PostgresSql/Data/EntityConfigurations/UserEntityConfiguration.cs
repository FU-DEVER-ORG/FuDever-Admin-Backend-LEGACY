using FuDever.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuDever.PostgresSql.Data.EntityConfigurations;

/// <summary>
///     Represent "Users" table configuration.
/// </summary>
internal sealed class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        const string TableName = "Users";
        const string TableComment = "Contain user record.";

        builder.ToTable(
            name: TableName,
            buildAction: table => table.HasComment(comment: TableComment)
        );

        // Table relationship configurations.
        // [Users] - [UserDetails] (1 - 1)
        builder
            .HasOne(navigationExpression: user => user.UserDetail)
            .WithOne(navigationExpression: userDetail => userDetail.User)
            .HasForeignKey<User>(foreignKeyExpression: userDetail => userDetail.Id)
            .IsRequired();

        // [Users] - [UserRoles] (1 - N).
        builder
            .HasMany(navigationExpression: user => user.UserRoles)
            .WithOne(navigationExpression: userRole => userRole.User)
            .HasForeignKey(foreignKeyExpression: userRole => userRole.UserId)
            .IsRequired();

        // [Users] - [UserTokens] (1 - N).
        builder
            .HasMany(navigationExpression: user => user.UserTokens)
            .WithOne(navigationExpression: userToken => userToken.User)
            .HasForeignKey(foreignKeyExpression: userToken => userToken.UserId)
            .IsRequired();
    }
}
