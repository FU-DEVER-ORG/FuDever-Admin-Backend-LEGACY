using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuDever.PostgresSql.Migrations
{
    /// <inheritdoc />
    public partial class M3_Alter_RefreshTokens_Table_Fields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_UserDetails_CreatedBy",
                table: "RefreshTokens"
            );

            migrationBuilder.DropPrimaryKey(name: "PK_RefreshTokens", table: "RefreshTokens");

            migrationBuilder.DropIndex(name: "IX_RefreshTokens_CreatedBy", table: "RefreshTokens");

            migrationBuilder.DropColumn(name: "Id", table: "RefreshTokens");

            migrationBuilder.DropColumn(name: "CreatedBy", table: "RefreshTokens");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "RefreshTokens",
                newName: "RefreshTokenValue"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserDetails",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMPTZ"
            );

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens",
                column: "AccessTokenId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(name: "PK_RefreshTokens", table: "RefreshTokens");

            migrationBuilder.RenameColumn(
                name: "RefreshTokenValue",
                table: "RefreshTokens",
                newName: "Value"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserDetails",
                type: "TIMESTAMPTZ",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone"
            );

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "RefreshTokens",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "RefreshTokens",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens",
                column: "Id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_CreatedBy",
                table: "RefreshTokens",
                column: "CreatedBy"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_UserDetails_CreatedBy",
                table: "RefreshTokens",
                column: "CreatedBy",
                principalTable: "UserDetails",
                principalColumn: "Id"
            );
        }
    }
}
