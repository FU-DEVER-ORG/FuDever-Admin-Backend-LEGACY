using FuDever.Domain.Entities;
using FuDever.PostgresSql.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuDever.PostgresSql.Data.EntityConfigurations;

/// <summary>
///     Represent "RefreshTokens" table configuration.
/// </summary>
internal sealed class RefreshTokenEntityConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        const string TableName = "RefreshTokens";
        const string TableComment = "Contain refresh token record.";

        builder.ToTable(
            name: TableName,
            buildAction: table => table.HasComment(comment: TableComment)
        );

        // Primary key configuration.
        builder.HasKey(keyExpression: refreshToken => refreshToken.AccessTokenId);

        // RefreshTokenValue property configuration.
        builder
            .Property(propertyExpression: refreshToken => refreshToken.RefreshTokenValue)
            .HasColumnType(
                typeName: CommonConstant.DbDataType.VarcharGenerator.Get(
                    length: RefreshToken.Metadata.RefreshTokenValue.MaxLength
                )
            )
            .IsRequired();

        // ExpiredDate property configuration.
        builder
            .Property(propertyExpression: refreshToken => refreshToken.ExpiredDate)
            .HasColumnType(typeName: CommonConstant.DbDataType.TIMESTAMPTZ)
            .IsRequired();

        // CreatedAt property configuration.
        builder
            .Property(propertyExpression: refreshToken => refreshToken.CreatedAt)
            .HasColumnType(typeName: CommonConstant.DbDataType.TIMESTAMPTZ)
            .IsRequired();
    }
}
