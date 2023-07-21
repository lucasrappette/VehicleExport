﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleExport.App.DAL;

#nullable disable

namespace VehicleExport.App.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("IdentityUserRole<long>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("VehicleExport.App.Models.Data.Accounts.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("9770d744-5c62-4d76-a4ef-163f94b33dad"),
                            ConcurrencyStamp = "8fc29173-60d5-47e8-b385-5787ed828c23",
                            Name = "SuperAdmin",
                            NormalizedName = "SuperAdmin"
                        },
                        new
                        {
                            Id = new Guid("558669b9-49a9-4520-90b8-51ba5b12c33e"),
                            ConcurrencyStamp = "156d40fd-95c1-4e4c-9c0e-e207e3c6a6fb",
                            Name = "ProjectManager",
                            NormalizedName = "ProjectManager"
                        },
                        new
                        {
                            Id = new Guid("b67f4c23-5886-41ee-bbbb-6ae377f8f2ad"),
                            ConcurrencyStamp = "6820b806-f9cf-4773-ba89-260d8b88c24f",
                            Name = "ProjectViewer",
                            NormalizedName = "ProjectViewer"
                        },
                        new
                        {
                            Id = new Guid("18b6e930-29db-4c03-88e9-840adf59f2f7"),
                            ConcurrencyStamp = "59a41259-af4e-467b-9031-62076c326d95",
                            Name = "ContentManager",
                            NormalizedName = "ContentManager"
                        });
                });

            modelBuilder.Entity("VehicleExport.App.Models.Data.Accounts.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c9db7b0d-5889-4a71-b1a9-cf59ef2fa4be"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "02f01ff0-0864-455d-9965-fc976f1d5ec7",
                            Email = "admin@test.com",
                            EmailConfirmed = true,
                            FirstName = "Admin",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@TEST.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEJuxBuIYGck7obz16r21XoUULaVPjQ9CzCQqszFkoIGVgCXp2BkxyGSSAayWD3WDtQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("VehicleExport.App.Models.Data.Accounts.ApplicationUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("c9db7b0d-5889-4a71-b1a9-cf59ef2fa4be"),
                            RoleId = new Guid("9770d744-5c62-4d76-a4ef-163f94b33dad"),
                            Id = new Guid("a58fba01-5af7-4955-9c4b-48b31c728d0b")
                        },
                        new
                        {
                            UserId = new Guid("c9db7b0d-5889-4a71-b1a9-cf59ef2fa4be"),
                            RoleId = new Guid("558669b9-49a9-4520-90b8-51ba5b12c33e"),
                            Id = new Guid("b5a1b0b6-c3e3-415c-82e0-6aeae117a4c1")
                        },
                        new
                        {
                            UserId = new Guid("c9db7b0d-5889-4a71-b1a9-cf59ef2fa4be"),
                            RoleId = new Guid("b67f4c23-5886-41ee-bbbb-6ae377f8f2ad"),
                            Id = new Guid("5c7c94d6-c895-40f3-9bf8-f11019f33c25")
                        },
                        new
                        {
                            UserId = new Guid("c9db7b0d-5889-4a71-b1a9-cf59ef2fa4be"),
                            RoleId = new Guid("18b6e930-29db-4c03-88e9-840adf59f2f7"),
                            Id = new Guid("ac6c0cfe-5d57-4860-b27a-09485b5aa41e")
                        });
                });

            modelBuilder.Entity("VehicleExport.App.Models.Data.Accounts.ExternalCredential", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("ConcurrencyTimestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("ExternalId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Provider")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("ExternalCredentials");
                });

            modelBuilder.Entity("VehicleExport.App.Models.Data.Content.ContentBlock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AllowedTokens")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ConcurrencyTimestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPage")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.Property<string>("Slug")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Slug");

                    b.ToTable("ContentBlocks", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                        {
                            ttb
                                .HasPeriodStart("PeriodStart")
                                .HasColumnName("PeriodStart");
                            ttb
                                .HasPeriodEnd("PeriodEnd")
                                .HasColumnName("PeriodEnd");
                        }
                    ));

                    b.HasData(
                        new
                        {
                            Id = new Guid("cfe1f7d4-369a-40cc-861e-899be751efc1"),
                            AllowedTokens = "[{\"Token\":\"passwordResetUrl\",\"Description\":\"The URL for the user to reset their password\"}]",
                            Description = "The text that appears in a password reset message",
                            IsPage = false,
                            Slug = "password-reset-email",
                            Title = "Reset Your Password",
                            Value = "To reset your account, follow this link: %passwordResetUrl%"
                        },
                        new
                        {
                            Id = new Guid("33a97843-3023-4d79-99bf-0ddead3c43d5"),
                            Description = "The text that appears on the About page",
                            IsPage = true,
                            Slug = "about",
                            Title = "About Us",
                            Value = "About us..."
                        },
                        new
                        {
                            Id = new Guid("16a9cd41-ccf9-4915-b233-6b870e5008a2"),
                            Description = "",
                            IsPage = true,
                            Slug = "placeholder",
                            Title = "Placeholder",
                            Value = "This is a placeholder page. The underlying functionality has not yet been implemented."
                        },
                        new
                        {
                            Id = new Guid("b3fd96cd-aa12-4f15-9df1-6418fa608e15"),
                            Description = "Content that appears on the Home/Dashboard page",
                            IsPage = false,
                            Slug = "dashboard",
                            Title = "Hello",
                            Value = "Hello, world. Or whoever else is here. This content is editable within the app."
                        },
                        new
                        {
                            Id = new Guid("5d480ee9-f8e4-4ef1-b70c-3e53bec40200"),
                            Description = "The help page that appears in the top nav",
                            IsPage = true,
                            Slug = "help",
                            Title = "Help!",
                            Value = "Need help? Don't we all."
                        });
                });

            modelBuilder.Entity("VehicleExport.App.Models.Data.Dealers.Dealer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressLineOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLineTwo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ConcurrencyTimestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("DealerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Inactive")
                        .HasColumnType("bit");

                    b.Property<decimal>("Mileage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PrimaryProjectManagerApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PrimaryProjectManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SalesRepApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SalesRepId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("PrimaryProjectManagerId");

                    b.HasIndex("SalesRepId");

                    b.ToTable("Dealers", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                        {
                            ttb
                                .HasPeriodStart("PeriodStart")
                                .HasColumnName("PeriodStart");
                            ttb
                                .HasPeriodEnd("PeriodEnd")
                                .HasColumnName("PeriodEnd");
                        }
                    ));

                    b.HasData(
                        new
                        {
                            Id = new Guid("330763c3-43de-432d-b61d-526c1a0c9542"),
                            AddressLineOne = "1600 Amphitheatre Pkwy",
                            City = "Mountain View",
                            DescriptionNotes = "This Dealer is google",
                            Inactive = false,
                            Mileage = 0m,
                            Name = "Alphabet Inc.",
                            PhoneNumber = "650-253-0000",
                            PostalCode = "94043",
                            PrimaryProjectManagerApplicationUserId = new Guid("c9db7b0d-5889-4a71-b1a9-cf59ef2fa4be"),
                            SalesRepApplicationUserId = new Guid("c9db7b0d-5889-4a71-b1a9-cf59ef2fa4be"),
                            State = "CA"
                        },
                        new
                        {
                            Id = new Guid("fa408c98-b0e7-4044-9be8-e06d4d0c06ad"),
                            AddressLineOne = "1552 E Capitol Dr",
                            City = "Shorewood",
                            DescriptionNotes = "This Dealer is us",
                            Inactive = false,
                            Mileage = 0m,
                            Name = "Northwoods",
                            PhoneNumber = "650-253-0000",
                            PostalCode = "53211",
                            PrimaryProjectManagerApplicationUserId = new Guid("c9db7b0d-5889-4a71-b1a9-cf59ef2fa4be"),
                            SalesRepApplicationUserId = new Guid("c9db7b0d-5889-4a71-b1a9-cf59ef2fa4be"),
                            State = "WI"
                        });
                });

            modelBuilder.Entity("VehicleExport.App.Models.Data.Dealers.DealerStats", b =>
                {
                    b.Property<Guid>("DealerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DealerId");

                    b.ToView("DealerStats");
                });

            modelBuilder.Entity("VehicleExport.App.Models.Data.Destinations.Destination", b =>
                {
                    b.Property<int>("DestinationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DestinationId"), 1L, 1);

                    b.Property<byte[]>("ConcurrencyTimestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("FtpHost")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FtpPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FtpRemoteDir")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FtpUsername")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DestinationId");

                    b.HasIndex("DestinationId");

                    b.ToTable("Destinations", (string)null);
                });

            modelBuilder.Entity("VehicleExport.App.Models.Data.Exports.Export", b =>
                {
                    b.Property<int>("ExportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExportId"), 1L, 1);

                    b.Property<byte[]>("ConcurrencyTimestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("DestinationId")
                        .HasColumnType("int");

                    b.Property<string>("ExportName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LayoutId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RunTimeOne")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RunTimeTwo")
                        .HasColumnType("datetime2");

                    b.HasKey("ExportId");

                    b.HasIndex("DestinationId");

                    b.HasIndex("ExportId");

                    b.HasIndex("LayoutId");

                    b.ToTable("Exports", (string)null);
                });

            modelBuilder.Entity("VehicleExport.App.Models.Data.Jobs.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Ended")
                        .HasColumnType("datetime2");

                    b.Property<long>("ExpectedCount")
                        .HasColumnType("bigint");

                    b.Property<long>("FailureCount")
                        .HasColumnType("bigint");

                    b.Property<string>("ItemType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.Property<string>("SerializedItemIds")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ItemIds");

                    b.Property<DateTime?>("Started")
                        .HasColumnType("datetime2");

                    b.Property<long>("SuccessCount")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Created");

                    b.ToTable("Jobs", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                        {
                            ttb
                                .HasPeriodStart("PeriodStart")
                                .HasColumnName("PeriodStart");
                            ttb
                                .HasPeriodEnd("PeriodEnd")
                                .HasColumnName("PeriodEnd");
                        }
                    ));
                });

            modelBuilder.Entity("VehicleExport.App.Models.Data.Jobs.JobItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("JobItems", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                        {
                            ttb
                                .HasPeriodStart("PeriodStart")
                                .HasColumnName("PeriodStart");
                            ttb
                                .HasPeriodEnd("PeriodEnd")
                                .HasColumnName("PeriodEnd");
                        }
                    ));
                });

            modelBuilder.Entity("VehicleExport.App.Models.Data.Layouts.Layout", b =>
                {
                    b.Property<int>("LayoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LayoutId"), 1L, 1);

                    b.Property<byte[]>("ConcurrencyTimestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("LayoutId");

                    b.HasIndex("LayoutId");

                    b.ToTable("Layouts", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("VehicleExport.App.Models.Data.Accounts.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("VehicleExport.App.Models.Data.Accounts.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("VehicleExport.App.Models.Data.Accounts.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("VehicleExport.App.Models.Data.Accounts.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VehicleExport.App.Models.Data.Accounts.ApplicationUserRole", b =>
                {
                    b.HasOne("VehicleExport.App.Models.Data.Accounts.ApplicationRole", "ApplicationRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VehicleExport.App.Models.Data.Accounts.ApplicationUser", "ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationRole");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("VehicleExport.App.Models.Data.Accounts.ExternalCredential", b =>
                {
                    b.HasOne("VehicleExport.App.Models.Data.Accounts.ApplicationUser", "ApplicationUser")
                        .WithMany("ExternalCredentials")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("VehicleExport.App.Models.Data.Dealers.Dealer", b =>
                {
                    b.HasOne("VehicleExport.App.Models.Data.Accounts.ApplicationUser", "PrimaryProjectManager")
                        .WithMany()
                        .HasForeignKey("PrimaryProjectManagerId");

                    b.HasOne("VehicleExport.App.Models.Data.Accounts.ApplicationUser", "SalesRep")
                        .WithMany()
                        .HasForeignKey("SalesRepId");

                    b.Navigation("PrimaryProjectManager");

                    b.Navigation("SalesRep");
                });

            modelBuilder.Entity("VehicleExport.App.Models.Data.Dealers.DealerStats", b =>
                {
                    b.HasOne("VehicleExport.App.Models.Data.Dealers.Dealer", "Dealer")
                        .WithOne("DealerStats")
                        .HasForeignKey("VehicleExport.App.Models.Data.Dealers.DealerStats", "DealerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dealer");
                });

            modelBuilder.Entity("VehicleExport.App.Models.Data.Exports.Export", b =>
                {
                    b.HasOne("VehicleExport.App.Models.Data.Destinations.Destination", "Destination")
                        .WithMany("Exports")
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VehicleExport.App.Models.Data.Layouts.Layout", "Layout")
                        .WithMany("Exports")
                        .HasForeignKey("LayoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destination");

                    b.Navigation("Layout");
                });

            modelBuilder.Entity("VehicleExport.App.Models.Data.Jobs.JobItem", b =>
                {
                    b.HasOne("VehicleExport.App.Models.Data.Jobs.Job", "Job")
                        .WithMany("JobItems")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("VehicleExport.App.Models.Data.Accounts.ApplicationRole", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("VehicleExport.App.Models.Data.Accounts.ApplicationUser", b =>
                {
                    b.Navigation("ExternalCredentials");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("VehicleExport.App.Models.Data.Dealers.Dealer", b =>
                {
                    b.Navigation("DealerStats");
                });

            modelBuilder.Entity("VehicleExport.App.Models.Data.Destinations.Destination", b =>
                {
                    b.Navigation("Exports");
                });

            modelBuilder.Entity("VehicleExport.App.Models.Data.Jobs.Job", b =>
                {
                    b.Navigation("JobItems");
                });

            modelBuilder.Entity("VehicleExport.App.Models.Data.Layouts.Layout", b =>
                {
                    b.Navigation("Exports");
                });
#pragma warning restore 612, 618
        }
    }
}
