using FuDever.Domain.Entities;
using FuDever.PostgresSql.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuDever.PostgresSql.Data.EntityConfigurations;

/// <summary>
///     Represent "Departments" tables configuration.
/// </summary>
internal sealed class DepartmentEntityConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        const string TableName = "Departments";
        const string TableComment = "Contain department record.";

        builder.ToTable(
            name: TableName,
            buildAction: table => table.HasComment(comment: TableComment)
        );

        // Primary key configuration.
        builder.HasKey(keyExpression: department => department.Id);

        // Name property configuration.
        builder
            .Property(propertyExpression: department => department.Name)
            .HasColumnType(
                typeName: CommonConstant.DbDataType.VarcharGenerator.Get(
                    length: Department.Metadata.Name.MaxLength
                )
            )
            .IsRequired();

        // RemovedAt property configuration.
        builder
            .Property(propertyExpression: department => department.RemovedAt)
            .HasColumnType(typeName: CommonConstant.DbDataType.TIMESTAMPTZ)
            .IsRequired();

        // RemovedBy property configuration.
        builder.Property(propertyExpression: department => department.RemovedBy).IsRequired();

        // Table relationships configurations.
        // [Departments] - [UserDetails] (1 - N).
        builder
            .HasMany(navigationExpression: department => department.UserDetails)
            .WithOne(navigationExpression: userDetail => userDetail.Department)
            .HasForeignKey(foreignKeyExpression: user => user.DepartmentId)
            .OnDelete(deleteBehavior: DeleteBehavior.NoAction);
    }
}
