using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuDever.PostgresSql.Migrations
{
    /// <inheritdoc />
    public partial class M2_Seperate_user_table_into_2_table_and_refactor_the_relationships
        : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_Users_AuthorId",
                table: "BlogComments"
            );

            migrationBuilder.DropForeignKey(name: "FK_Blogs_Users_AuthorId", table: "Blogs");

            migrationBuilder.DropForeignKey(name: "FK_Projects_Users_AuthorId", table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_CreatedBy",
                table: "RefreshTokens"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users"
            );

            migrationBuilder.DropForeignKey(name: "FK_Users_Majors_MajorId", table: "Users");

            migrationBuilder.DropForeignKey(name: "FK_Users_Positions_PositionId", table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserJoiningStatuses_UserJoiningStatusId",
                table: "Users"
            );

            migrationBuilder.DropIndex(name: "IX_Users_DepartmentId", table: "Users");

            migrationBuilder.DropIndex(name: "IX_Users_MajorId", table: "Users");

            migrationBuilder.DropIndex(name: "IX_Users_PositionId", table: "Users");

            migrationBuilder.DropIndex(name: "IX_Users_UserJoiningStatusId", table: "Users");

            migrationBuilder.DropColumn(name: "ActivityPoints", table: "Users");

            migrationBuilder.DropColumn(name: "AvatarUrl", table: "Users");

            migrationBuilder.DropColumn(name: "BirthDay", table: "Users");

            migrationBuilder.DropColumn(name: "Career", table: "Users");

            migrationBuilder.DropColumn(name: "CreatedAt", table: "Users");

            migrationBuilder.DropColumn(name: "CreatedBy", table: "Users");

            migrationBuilder.DropColumn(name: "DepartmentId", table: "Users");

            migrationBuilder.DropColumn(name: "EducationPlaces", table: "Users");

            migrationBuilder.DropColumn(name: "FirstName", table: "Users");

            migrationBuilder.DropColumn(name: "HomeAddress", table: "Users");

            migrationBuilder.DropColumn(name: "JoinDate", table: "Users");

            migrationBuilder.DropColumn(name: "LastName", table: "Users");

            migrationBuilder.DropColumn(name: "MajorId", table: "Users");

            migrationBuilder.DropColumn(name: "PositionId", table: "Users");

            migrationBuilder.DropColumn(name: "RemovedAt", table: "Users");

            migrationBuilder.DropColumn(name: "RemovedBy", table: "Users");

            migrationBuilder.DropColumn(name: "SelfDescription", table: "Users");

            migrationBuilder.DropColumn(name: "UpdatedAt", table: "Users");

            migrationBuilder.DropColumn(name: "UpdatedBy", table: "Users");

            migrationBuilder.DropColumn(name: "UserHobbies", table: "Users");

            migrationBuilder.DropColumn(name: "UserJoiningStatusId", table: "Users");

            migrationBuilder.DropColumn(name: "UserPlatforms", table: "Users");

            migrationBuilder.DropColumn(name: "UserSkills", table: "Users");

            migrationBuilder.DropColumn(name: "Workplaces", table: "Users");

            migrationBuilder.DropColumn(name: "Discriminator", table: "UserLogins");

            migrationBuilder.DropColumn(name: "Discriminator", table: "UserClaims");

            migrationBuilder.DropColumn(name: "Discriminator", table: "RoleClaims");

            migrationBuilder.AlterTable(
                name: "UserLogins",
                oldComment: "Contain user login record."
            );

            migrationBuilder.AlterTable(
                name: "UserClaims",
                oldComment: "Contain user claim record."
            );

            migrationBuilder.AlterTable(
                name: "RoleClaims",
                oldComment: "Contain role claim record."
            );

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserJoiningStatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionId = table.Column<Guid>(type: "uuid", nullable: false),
                    MajorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    Career = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    Workplaces = table.Column<string>(type: "TEXT", nullable: false),
                    UserSkills = table.Column<string>(type: "TEXT", nullable: false),
                    UserHobbies = table.Column<string>(type: "TEXT", nullable: false),
                    UserPlatforms = table.Column<string>(type: "TEXT", nullable: false),
                    EducationPlaces = table.Column<string>(type: "TEXT", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    HomeAddress = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    SelfDescription = table.Column<string>(type: "TEXT", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    ActivityPoints = table.Column<short>(type: "smallint", nullable: false),
                    AvatarUrl = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    RemovedAt = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    RemovedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDetails_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id"
                    );
                    table.ForeignKey(
                        name: "FK_UserDetails_Majors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Majors",
                        principalColumn: "Id"
                    );
                    table.ForeignKey(
                        name: "FK_UserDetails_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id"
                    );
                    table.ForeignKey(
                        name: "FK_UserDetails_UserJoiningStatuses_UserJoiningStatusId",
                        column: x => x.UserJoiningStatusId,
                        principalTable: "UserJoiningStatuses",
                        principalColumn: "Id"
                    );
                },
                comment: "Contain user detail record."
            );

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_DepartmentId",
                table: "UserDetails",
                column: "DepartmentId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_MajorId",
                table: "UserDetails",
                column: "MajorId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_PositionId",
                table: "UserDetails",
                column: "PositionId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserJoiningStatusId",
                table: "UserDetails",
                column: "UserJoiningStatusId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_UserDetails_AuthorId",
                table: "BlogComments",
                column: "AuthorId",
                principalTable: "UserDetails",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_UserDetails_AuthorId",
                table: "Blogs",
                column: "AuthorId",
                principalTable: "UserDetails",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_UserDetails_AuthorId",
                table: "Projects",
                column: "AuthorId",
                principalTable: "UserDetails",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_UserDetails_CreatedBy",
                table: "RefreshTokens",
                column: "CreatedBy",
                principalTable: "UserDetails",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserDetails_Id",
                table: "Users",
                column: "Id",
                principalTable: "UserDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_UserDetails_AuthorId",
                table: "BlogComments"
            );

            migrationBuilder.DropForeignKey(name: "FK_Blogs_UserDetails_AuthorId", table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_UserDetails_AuthorId",
                table: "Projects"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_UserDetails_CreatedBy",
                table: "RefreshTokens"
            );

            migrationBuilder.DropForeignKey(name: "FK_Users_UserDetails_Id", table: "Users");

            migrationBuilder.DropTable(name: "UserDetails");

            migrationBuilder.AlterTable(name: "UserLogins", comment: "Contain user login record.");

            migrationBuilder.AlterTable(name: "UserClaims", comment: "Contain user claim record.");

            migrationBuilder.AlterTable(name: "RoleClaims", comment: "Contain role claim record.");

            migrationBuilder.AddColumn<short>(
                name: "ActivityPoints",
                table: "Users",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0
            );

            migrationBuilder.AddColumn<string>(
                name: "AvatarUrl",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "Users",
                type: "TIMESTAMPTZ",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.AddColumn<string>(
                name: "Career",
                table: "Users",
                type: "VARCHAR(30)",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "TIMESTAMPTZ",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );

            migrationBuilder.AddColumn<string>(
                name: "EducationPlaces",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "VARCHAR(30)",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<string>(
                name: "HomeAddress",
                table: "Users",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinDate",
                table: "Users",
                type: "TIMESTAMPTZ",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "VARCHAR(30)",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<Guid>(
                name: "MajorId",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );

            migrationBuilder.AddColumn<Guid>(
                name: "PositionId",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedAt",
                table: "Users",
                type: "TIMESTAMPTZ",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.AddColumn<Guid>(
                name: "RemovedBy",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );

            migrationBuilder.AddColumn<string>(
                name: "SelfDescription",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "TIMESTAMPTZ",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );

            migrationBuilder.AddColumn<string>(
                name: "UserHobbies",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<Guid>(
                name: "UserJoiningStatusId",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );

            migrationBuilder.AddColumn<string>(
                name: "UserPlatforms",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<string>(
                name: "UserSkills",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<string>(
                name: "Workplaces",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "UserLogins",
                type: "character varying(34)",
                maxLength: 34,
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "UserClaims",
                type: "character varying(34)",
                maxLength: 34,
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "RoleClaims",
                type: "character varying(34)",
                maxLength: 34,
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Users_MajorId",
                table: "Users",
                column: "MajorId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Users_PositionId",
                table: "Users",
                column: "PositionId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserJoiningStatusId",
                table: "Users",
                column: "UserJoiningStatusId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_Users_AuthorId",
                table: "BlogComments",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Users_AuthorId",
                table: "Blogs",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_AuthorId",
                table: "Projects",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_CreatedBy",
                table: "RefreshTokens",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Majors_MajorId",
                table: "Users",
                column: "MajorId",
                principalTable: "Majors",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Positions_PositionId",
                table: "Users",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserJoiningStatuses_UserJoiningStatusId",
                table: "Users",
                column: "UserJoiningStatusId",
                principalTable: "UserJoiningStatuses",
                principalColumn: "Id"
            );
        }
    }
}
