﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FuDever.PostgresSql.Migrations
{
    /// <inheritdoc />
    public partial class M1_Init_Db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .AlterDatabase()
                .Annotation(
                    "Npgsql:CollationDefinition:case_insensitive",
                    "en-u-ks-primary,en-u-ks-primary,icu,False"
                );

            migrationBuilder.CreateTable(
                name: "Cvs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentFullName = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    StudentEmail = table.Column<string>(type: "TEXT", nullable: false),
                    StudentId = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    StudentCvFileId = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    RemovedAt = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    RemovedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cvs", x => x.Id);
                },
                comment: "Contain cv record."
            );

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    RemovedAt = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    RemovedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                },
                comment: "Contain department record."
            );

            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    RemovedAt = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    RemovedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.Id);
                },
                comment: "Contain hobby record."
            );

            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    RemovedAt = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    RemovedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.Id);
                },
                comment: "Contain major record."
            );

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    RemovedAt = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    RemovedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                },
                comment: "Contain platform record."
            );

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    RemovedAt = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    RemovedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                },
                comment: "Contain position record."
            );

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RemovedAt = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    RemovedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(
                        type: "character varying(256)",
                        maxLength: 256,
                        nullable: true
                    ),
                    NormalizedName = table.Column<string>(
                        type: "character varying(256)",
                        maxLength: 256,
                        nullable: true
                    ),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                },
                comment: "Contain role record."
            );

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    RemovedAt = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    RemovedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                },
                comment: "Contain skill record."
            );

            migrationBuilder.CreateTable(
                name: "UserJoiningStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    RemovedAt = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    RemovedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJoiningStatuses", x => x.Id);
                },
                comment: "Contain user joining status record."
            );

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(
                        type: "character varying(34)",
                        maxLength: 34,
                        nullable: false
                    )
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                },
                comment: "Contain role claim record."
            );

            migrationBuilder.CreateTable(
                name: "Users",
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
                    RemovedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(
                        type: "character varying(256)",
                        maxLength: 256,
                        nullable: true
                    ),
                    NormalizedUserName = table.Column<string>(
                        type: "character varying(256)",
                        maxLength: 256,
                        nullable: true
                    ),
                    Email = table.Column<string>(
                        type: "character varying(256)",
                        maxLength: 256,
                        nullable: true
                    ),
                    NormalizedEmail = table.Column<string>(
                        type: "character varying(256)",
                        maxLength: 256,
                        nullable: true
                    ),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(
                        type: "timestamp with time zone",
                        nullable: true
                    ),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id"
                    );
                    table.ForeignKey(
                        name: "FK_Users_Majors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Majors",
                        principalColumn: "Id"
                    );
                    table.ForeignKey(
                        name: "FK_Users_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id"
                    );
                    table.ForeignKey(
                        name: "FK_Users_UserJoiningStatuses_UserJoiningStatusId",
                        column: x => x.UserJoiningStatusId,
                        principalTable: "UserJoiningStatuses",
                        principalColumn: "Id"
                    );
                },
                comment: "Contain user record."
            );

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Thumbnail = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    BlogTags = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    RemovedAt = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    RemovedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id"
                    );
                },
                comment: "Contain blog record."
            );

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    SourceCodeUrl = table.Column<string>(type: "TEXT", nullable: false),
                    DemoUrl = table.Column<string>(type: "TEXT", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id"
                    );
                },
                comment: "Contain project record."
            );

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    AccessTokenId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id"
                    );
                },
                comment: "Contain refresh token record."
            );

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(
                        type: "character varying(34)",
                        maxLength: 34,
                        nullable: false
                    )
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                },
                comment: "Contain user claim record."
            );

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Discriminator = table.Column<string>(
                        type: "character varying(34)",
                        maxLength: 34,
                        nullable: false
                    )
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                },
                comment: "Contain user login record."
            );

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Discriminator = table.Column<string>(
                        type: "character varying(34)",
                        maxLength: 34,
                        nullable: false
                    )
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                },
                comment: "Contain user role record."
            );

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(
                        type: "character varying(34)",
                        maxLength: 34,
                        nullable: false
                    )
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_UserTokens",
                        x => new
                        {
                            x.UserId,
                            x.LoginProvider,
                            x.Name
                        }
                    );
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                },
                comment: "Contain user token record."
            );

            migrationBuilder.CreateTable(
                name: "BlogComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BlogId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogComments_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id"
                    );
                    table.ForeignKey(
                        name: "FK_BlogComments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id"
                    );
                },
                comment: "Contain blog comment record."
            );

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_AuthorId",
                table: "BlogComments",
                column: "AuthorId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_BlogId",
                table: "BlogComments",
                column: "BlogId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_AuthorId",
                table: "Blogs",
                column: "AuthorId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AuthorId",
                table: "Projects",
                column: "AuthorId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_CreatedBy",
                table: "RefreshTokens",
                column: "CreatedBy"
            );

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId"
            );

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId"
            );

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail"
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

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "BlogComments");

            migrationBuilder.DropTable(name: "Cvs");

            migrationBuilder.DropTable(name: "Hobbies");

            migrationBuilder.DropTable(name: "Platforms");

            migrationBuilder.DropTable(name: "Projects");

            migrationBuilder.DropTable(name: "RefreshTokens");

            migrationBuilder.DropTable(name: "RoleClaims");

            migrationBuilder.DropTable(name: "Skills");

            migrationBuilder.DropTable(name: "UserClaims");

            migrationBuilder.DropTable(name: "UserLogins");

            migrationBuilder.DropTable(name: "UserRoles");

            migrationBuilder.DropTable(name: "UserTokens");

            migrationBuilder.DropTable(name: "Blogs");

            migrationBuilder.DropTable(name: "Roles");

            migrationBuilder.DropTable(name: "Users");

            migrationBuilder.DropTable(name: "Departments");

            migrationBuilder.DropTable(name: "Majors");

            migrationBuilder.DropTable(name: "Positions");

            migrationBuilder.DropTable(name: "UserJoiningStatuses");
        }
    }
}
