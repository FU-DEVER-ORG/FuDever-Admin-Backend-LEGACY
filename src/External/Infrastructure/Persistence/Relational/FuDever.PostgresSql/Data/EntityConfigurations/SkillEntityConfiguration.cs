using FuDever.Domain.Entities;
using FuDever.PostgresSql.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuDever.PostgresSql.Data.EntityConfigurations;

/// <summary>
///     Represent "Skills" table configuration.
/// </summary>
internal sealed class SkillEntityConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        const string TableName = "Skills";
        const string TableComment = "Contain skill record.";

        builder.ToTable(
            name: TableName,
            buildAction: table => table.HasComment(comment: TableComment)
        );

        // Primary key configuration.
        builder.HasKey(keyExpression: skill => skill.Id);

        // Name property configuration.
        builder
            .Property(propertyExpression: skill => skill.Name)
            .HasColumnType(
                typeName: CommonConstant.DbDataType.VarcharGenerator.Get(
                    length: Skill.Metadata.Name.MaxLength
                )
            )
            .IsRequired();

        // RemovedAt property configuration.
        builder
            .Property(propertyExpression: skill => skill.RemovedAt)
            .HasColumnType(typeName: CommonConstant.DbDataType.TIMESTAMPTZ)
            .IsRequired();

        // RemovedBy property configuration.
        builder.Property(propertyExpression: skill => skill.RemovedBy).IsRequired();
    }
}
