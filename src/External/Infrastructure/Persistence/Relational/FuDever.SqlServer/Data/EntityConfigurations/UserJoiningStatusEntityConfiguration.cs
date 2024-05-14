using FuDever.Domain.Entities;
using FuDever.SqlServer.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuDever.SqlServer.Data.EntityConfigurations;

/// <summary>
///     Represent "UserJoiningStatuses" table configuration.
/// </summary>
internal sealed class UserJoiningStatusEntityConfiguration
    : IEntityTypeConfiguration<UserJoiningStatus>
{
    public void Configure(EntityTypeBuilder<UserJoiningStatus> builder)
    {
        const string TableName = "UserJoiningStatuses";
        const string TableComment = "Contain user joining status record.";

        builder.ToTable(
            name: TableName,
            buildAction: table => table.HasComment(comment: TableComment)
        );

        // Primary key configuration.
        builder.HasKey(keyExpression: userJoiningStatus => userJoiningStatus.Id);

        // Type property configuration.
        builder
            .Property(propertyExpression: userJoiningStatus => userJoiningStatus.Type)
            .HasColumnType(
                typeName: CommonConstant.DbDataType.NvarcharGenerator.Get(
                    length: UserJoiningStatus.Metadata.Type.MaxLength
                )
            )
            .IsRequired();

        // RemovedAt property configuration.
        builder
            .Property(propertyExpression: userJoiningStatus => userJoiningStatus.RemovedAt)
            .HasColumnType(typeName: CommonConstant.DbDataType.DATETIME_2)
            .IsRequired();

        // RemovedBy property configuration.
        builder
            .Property(propertyExpression: userJoiningStatus => userJoiningStatus.RemovedBy)
            .IsRequired();

        // Table relationship configurations.
        // [UserJoiningStatus] - [Users] (1 - N).
        builder
            .HasMany(navigationExpression: userJoiningStatus => userJoiningStatus.Users)
            .WithOne(navigationExpression: user => user.UserJoiningStatus)
            .HasForeignKey(foreignKeyExpression: user => user.UserJoiningStatusId)
            .OnDelete(deleteBehavior: DeleteBehavior.NoAction);
    }
}
