using FuDever.Domain.Entities;
using FuDever.SqlServer.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuDever.SqlServer.Data.EntityConfigurations;

/// <summary>
///     Represent "Hobbies" table configuration.
/// </summary>
internal sealed class HobbyEntityConfiguration : IEntityTypeConfiguration<Hobby>
{
    public void Configure(EntityTypeBuilder<Hobby> builder)
    {
        const string TableName = "Hobbies";
        const string TableComment = "Contain hobby record.";

        builder.ToTable(
            name: TableName,
            buildAction: table => table.HasComment(comment: TableComment)
        );

        // Primary key configuration.
        builder.HasKey(keyExpression: hobby => hobby.Id);

        // Name property configuration.
        builder
            .Property(propertyExpression: hobby => hobby.Name)
            .HasColumnType(
                typeName: CommonConstant.DbDataType.NvarcharGenerator.Get(
                    length: Hobby.Metadata.Name.MaxLength
                )
            )
            .IsRequired();

        // RemovedAt property configuration.
        builder
            .Property(propertyExpression: hobby => hobby.RemovedAt)
            .HasColumnType(typeName: CommonConstant.DbDataType.DATETIME_2)
            .IsRequired();

        // RemovedBy property configuration.
        builder.Property(propertyExpression: hobby => hobby.RemovedBy).IsRequired();

        // Table relationships configurations.
        // [Hobbies] - [UserHobbies] (1 - N).
        builder
            .HasMany(navigationExpression: hobby => hobby.UserHobbies)
            .WithOne(navigationExpression: userHobby => userHobby.Hobby)
            .HasForeignKey(foreignKeyExpression: userHobby => userHobby.HobbyId)
            .OnDelete(deleteBehavior: DeleteBehavior.NoAction);
    }
}
