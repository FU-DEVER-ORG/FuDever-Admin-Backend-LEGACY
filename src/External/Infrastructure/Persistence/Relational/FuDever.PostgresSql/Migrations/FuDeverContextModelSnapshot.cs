﻿// <auto-generated />
using System;
using FuDever.PostgresSql.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace FuDever.PostgresSql.Migrations
{
    [DbContext(typeof(FuDeverContext))]
    partial class FuDeverContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:CollationDefinition:case_insensitive", "en-u-ks-primary,en-u-ks-primary,icu,False")
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FuDever.Domain.Entities.Blog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<string>("BlogTags")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("RemovedAt")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<Guid>("RemovedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("TIMESTAMPTZ");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Blogs", null, t =>
                        {
                            t.HasComment("Contain blog record.");
                        });
                });

            modelBuilder.Entity("FuDever.Domain.Entities.BlogComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BlogId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("TIMESTAMPTZ");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BlogId");

                    b.ToTable("BlogComments", null, t =>
                        {
                            t.HasComment("Contain blog comment record.");
                        });
                });

            modelBuilder.Entity("FuDever.Domain.Entities.Cv", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("RemovedAt")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<Guid>("RemovedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("StudentCvFileId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentFullName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)");

                    b.HasKey("Id");

                    b.ToTable("Cvs", null, t =>
                        {
                            t.HasComment("Contain cv record.");
                        });
                });

            modelBuilder.Entity("FuDever.Domain.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<DateTime>("RemovedAt")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<Guid>("RemovedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Departments", null, t =>
                        {
                            t.HasComment("Contain department record.");
                        });
                });

            modelBuilder.Entity("FuDever.Domain.Entities.Hobby", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<DateTime>("RemovedAt")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<Guid>("RemovedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Hobbies", null, t =>
                        {
                            t.HasComment("Contain hobby record.");
                        });
                });

            modelBuilder.Entity("FuDever.Domain.Entities.Major", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<DateTime>("RemovedAt")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<Guid>("RemovedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Majors", null, t =>
                        {
                            t.HasComment("Contain major record.");
                        });
                });

            modelBuilder.Entity("FuDever.Domain.Entities.Platform", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<DateTime>("RemovedAt")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<Guid>("RemovedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Platforms", null, t =>
                        {
                            t.HasComment("Contain platform record.");
                        });
                });

            modelBuilder.Entity("FuDever.Domain.Entities.Position", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<DateTime>("RemovedAt")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<Guid>("RemovedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Positions", null, t =>
                        {
                            t.HasComment("Contain position record.");
                        });
                });

            modelBuilder.Entity("FuDever.Domain.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("DemoUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SourceCodeUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ThumbnailUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Projects", null, t =>
                        {
                            t.HasComment("Contain project record.");
                        });
                });

            modelBuilder.Entity("FuDever.Domain.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("AccessTokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<DateTime>("ExpiredDate")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<string>("RefreshTokenValue")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("AccessTokenId");

                    b.ToTable("RefreshTokens", null, t =>
                        {
                            t.HasComment("Contain refresh token record.");
                        });
                });

            modelBuilder.Entity("FuDever.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<DateTime>("RemovedAt")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<Guid>("RemovedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("Roles", null, t =>
                        {
                            t.HasComment("Contain role record.");
                        });
                });

            modelBuilder.Entity("FuDever.Domain.Entities.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<DateTime>("RemovedAt")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<Guid>("RemovedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Skills", null, t =>
                        {
                            t.HasComment("Contain skill record.");
                        });
                });

            modelBuilder.Entity("FuDever.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("Users", null, t =>
                        {
                            t.HasComment("Contain user record.");
                        });
                });

            modelBuilder.Entity("FuDever.Domain.Entities.UserDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<short>("ActivityPoints")
                        .HasColumnType("smallint");

                    b.Property<string>("AvatarUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<string>("Career")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("EducationPlaces")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<string>("HomeAddress")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<Guid>("MajorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PositionId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("RemovedAt")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<Guid>("RemovedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("SelfDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("UserHobbies")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserJoiningStatusId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserPlatforms")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserSkills")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Workplaces")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("MajorId");

                    b.HasIndex("PositionId");

                    b.HasIndex("UserJoiningStatusId");

                    b.ToTable("UserDetails", null, t =>
                        {
                            t.HasComment("Contain user detail record.");
                        });
                });

            modelBuilder.Entity("FuDever.Domain.Entities.UserJoiningStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("RemovedAt")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<Guid>("RemovedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.ToTable("UserJoiningStatuses", null, t =>
                        {
                            t.HasComment("Contain user joining status record.");
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(34)
                        .HasColumnType("character varying(34)");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserRoles", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<Guid>");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(34)
                        .HasColumnType("character varying(34)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserToken<Guid>");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("FuDever.Domain.Entities.UserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", null, t =>
                        {
                            t.HasComment("Contain user role record.");
                        });

                    b.HasDiscriminator().HasValue("UserRole");
                });

            modelBuilder.Entity("FuDever.Domain.Entities.UserToken", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>");

                    b.ToTable("UserTokens", null, t =>
                        {
                            t.HasComment("Contain user token record.");
                        });

                    b.HasDiscriminator().HasValue("UserToken");
                });

            modelBuilder.Entity("FuDever.Domain.Entities.Blog", b =>
                {
                    b.HasOne("FuDever.Domain.Entities.UserDetail", "UserDetail")
                        .WithMany("Blogs")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UserDetail");
                });

            modelBuilder.Entity("FuDever.Domain.Entities.BlogComment", b =>
                {
                    b.HasOne("FuDever.Domain.Entities.UserDetail", "UserDetail")
                        .WithMany("BlogComments")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FuDever.Domain.Entities.Blog", "Blog")
                        .WithMany("BlogComments")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Blog");

                    b.Navigation("UserDetail");
                });

            modelBuilder.Entity("FuDever.Domain.Entities.Project", b =>
                {
                    b.HasOne("FuDever.Domain.Entities.UserDetail", "UserDetail")
                        .WithMany("Projects")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UserDetail");
                });

            modelBuilder.Entity("FuDever.Domain.Entities.User", b =>
                {
                    b.HasOne("FuDever.Domain.Entities.UserDetail", "UserDetail")
                        .WithOne("User")
                        .HasForeignKey("FuDever.Domain.Entities.User", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserDetail");
                });

            modelBuilder.Entity("FuDever.Domain.Entities.UserDetail", b =>
                {
                    b.HasOne("FuDever.Domain.Entities.Department", "Department")
                        .WithMany("UserDetails")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FuDever.Domain.Entities.Major", "Major")
                        .WithMany("UserDetails")
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FuDever.Domain.Entities.Position", "Position")
                        .WithMany("UserDetails")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FuDever.Domain.Entities.UserJoiningStatus", "UserJoiningStatus")
                        .WithMany("UserDetails")
                        .HasForeignKey("UserJoiningStatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Major");

                    b.Navigation("Position");

                    b.Navigation("UserJoiningStatus");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("FuDever.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("FuDever.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("FuDever.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FuDever.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("FuDever.Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FuDever.Domain.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FuDever.Domain.Entities.UserToken", b =>
                {
                    b.HasOne("FuDever.Domain.Entities.User", "User")
                        .WithMany("UserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FuDever.Domain.Entities.Blog", b =>
                {
                    b.Navigation("BlogComments");
                });

            modelBuilder.Entity("FuDever.Domain.Entities.Department", b =>
                {
                    b.Navigation("UserDetails");
                });

            modelBuilder.Entity("FuDever.Domain.Entities.Major", b =>
                {
                    b.Navigation("UserDetails");
                });

            modelBuilder.Entity("FuDever.Domain.Entities.Position", b =>
                {
                    b.Navigation("UserDetails");
                });

            modelBuilder.Entity("FuDever.Domain.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("FuDever.Domain.Entities.User", b =>
                {
                    b.Navigation("UserRoles");

                    b.Navigation("UserTokens");
                });

            modelBuilder.Entity("FuDever.Domain.Entities.UserDetail", b =>
                {
                    b.Navigation("BlogComments");

                    b.Navigation("Blogs");

                    b.Navigation("Projects");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FuDever.Domain.Entities.UserJoiningStatus", b =>
                {
                    b.Navigation("UserDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
