using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleExport.App.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContentBlocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyTimestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsPage = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowedTokens = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentBlocks", x => x.Id);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ContentBlocksHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.CreateTable(
                name: "EncryptionType",
                columns: table => new
                {
                    EncryptionTypeId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncryptionType", x => x.EncryptionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserRole<long>",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole<long>", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Started = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ended = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpectedCount = table.Column<long>(type: "bigint", nullable: false),
                    SuccessCount = table.Column<long>(type: "bigint", nullable: false),
                    FailureCount = table.Column<long>(type: "bigint", nullable: false),
                    ItemType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ItemIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "JobsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.CreateTable(
                name: "LayoutDataSourceType",
                columns: table => new
                {
                    LayoutDataSourceTypeId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LayoutDataSourceType", x => x.LayoutDataSourceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LayoutFieldType",
                columns: table => new
                {
                    LayoutFieldTypeId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LayoutFieldType", x => x.LayoutFieldTypeId);
                });

            migrationBuilder.CreateTable(
                name: "OutputFormatType",
                columns: table => new
                {
                    OutputFormatTypeId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputFormatType", x => x.OutputFormatTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ProtocolType",
                columns: table => new
                {
                    ProtocolTypeId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProtocolType", x => x.ProtocolTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TransferModeType",
                columns: table => new
                {
                    TransferModeTypeId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferModeType", x => x.TransferModeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalCredentials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyTimestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Provider = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ExternalId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalCredentials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalCredentials_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobItems_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "JobItemsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.CreateTable(
                name: "Layouts",
                columns: table => new
                {
                    LayoutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StoredProcedureName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LayoutDataSourceTypeId = table.Column<short>(type: "smallint", nullable: false),
                    MakesList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertifiedOnly = table.Column<bool>(type: "bit", nullable: true),
                    NewVehicles = table.Column<bool>(type: "bit", nullable: true),
                    UsedVehicles = table.Column<bool>(type: "bit", nullable: true),
                    WarrantiesList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductsList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtmCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConcurrencyTimestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layouts", x => x.LayoutId);
                    table.ForeignKey(
                        name: "FK_Layouts_LayoutDataSourceType_LayoutDataSourceTypeId",
                        column: x => x.LayoutDataSourceTypeId,
                        principalTable: "LayoutDataSourceType",
                        principalColumn: "LayoutDataSourceTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LayoutFields",
                columns: table => new
                {
                    LayoutFieldId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LayoutFieldTypeId = table.Column<short>(type: "smallint", nullable: false),
                    DatabaseFieldLabel = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    DatabaseFieldSqlText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Parameter = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    dtmCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConcurrencyTimestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LayoutFields", x => x.LayoutFieldId);
                    table.ForeignKey(
                        name: "FK_LayoutFields_LayoutFieldType_LayoutFieldTypeId",
                        column: x => x.LayoutFieldTypeId,
                        principalTable: "LayoutFieldType",
                        principalColumn: "LayoutFieldTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    DestinationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FtpHost = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FtpUsername = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FtpPassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FtpRemoteDir = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProtocolTypeId = table.Column<short>(type: "smallint", nullable: false),
                    EncryptionTypeId = table.Column<short>(type: "smallint", nullable: false),
                    TransferModeTypeId = table.Column<short>(type: "smallint", nullable: false),
                    SSHKeyFileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    OutputFormatTypeId = table.Column<short>(type: "smallint", nullable: false),
                    UseQuotedFields = table.Column<bool>(type: "bit", nullable: false),
                    IncludeHeaders = table.Column<bool>(type: "bit", nullable: false),
                    OutputFileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZipOutputFile = table.Column<bool>(type: "bit", nullable: false),
                    OneFilePerDealer = table.Column<bool>(type: "bit", nullable: false),
                    SendPhotosInZip = table.Column<bool>(type: "bit", nullable: false),
                    dtmCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtmLastChanged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SshFilePassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SshKeyFileChecksum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyTimestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.DestinationId);
                    table.ForeignKey(
                        name: "FK_Destinations_EncryptionType_EncryptionTypeId",
                        column: x => x.EncryptionTypeId,
                        principalTable: "EncryptionType",
                        principalColumn: "EncryptionTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Destinations_OutputFormatType_OutputFormatTypeId",
                        column: x => x.OutputFormatTypeId,
                        principalTable: "OutputFormatType",
                        principalColumn: "OutputFormatTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Destinations_ProtocolType_ProtocolTypeId",
                        column: x => x.ProtocolTypeId,
                        principalTable: "ProtocolType",
                        principalColumn: "ProtocolTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Destinations_TransferModeType_TransferModeTypeId",
                        column: x => x.TransferModeTypeId,
                        principalTable: "TransferModeType",
                        principalColumn: "TransferModeTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LayoutFieldsMap",
                columns: table => new
                {
                    LayoutFieldsMapId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LayoutId = table.Column<int>(type: "int", nullable: false),
                    LayoutFieldId = table.Column<int>(type: "int", nullable: true),
                    HeaderLabel = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    FieldOrder = table.Column<short>(type: "smallint", nullable: false),
                    ConcurrencyTimestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LayoutFieldsMap", x => x.LayoutFieldsMapId);
                    table.ForeignKey(
                        name: "FK_LayoutFieldsMap_LayoutFields_LayoutFieldId",
                        column: x => x.LayoutFieldId,
                        principalTable: "LayoutFields",
                        principalColumn: "LayoutFieldId");
                    table.ForeignKey(
                        name: "FK_LayoutFieldsMap_Layouts_LayoutId",
                        column: x => x.LayoutId,
                        principalTable: "Layouts",
                        principalColumn: "LayoutId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exports",
                columns: table => new
                {
                    ExportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LayoutId = table.Column<int>(type: "int", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false),
                    RunTimeOne = table.Column<TimeSpan>(type: "time", nullable: true),
                    RunTimeTwo = table.Column<TimeSpan>(type: "time", nullable: true),
                    dtmCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtmLastChanged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConcurrencyTimestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exports", x => x.ExportId);
                    table.ForeignKey(
                        name: "FK_Exports_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "DestinationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exports_Layouts_LayoutId",
                        column: x => x.LayoutId,
                        principalTable: "Layouts",
                        principalColumn: "LayoutId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ExportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.CreateTable(
                name: "ExportDealers",
                columns: table => new
                {
                    ExportDealerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExportId = table.Column<int>(type: "int", nullable: false),
                    DealerId = table.Column<int>(type: "int", nullable: false),
                    dtmCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConcurrencyTimestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportDealers", x => x.ExportDealerId);
                    table.ForeignKey(
                        name: "FK_ExportDealers_Exports_ExportId",
                        column: x => x.ExportId,
                        principalTable: "Exports",
                        principalColumn: "ExportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExportTracking",
                columns: table => new
                {
                    ExportTrackingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExportId = table.Column<int>(type: "int", nullable: false),
                    ExportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyTimestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportTracking", x => x.ExportTrackingId);
                    table.ForeignKey(
                        name: "FK_ExportTracking_Exports_ExportId",
                        column: x => x.ExportId,
                        principalTable: "Exports",
                        principalColumn: "ExportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExportDealerParameters",
                columns: table => new
                {
                    ExportDealerParameterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExportDealerId = table.Column<int>(type: "int", nullable: false),
                    LayoutFieldId = table.Column<int>(type: "int", nullable: false),
                    ParameterValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dtmCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConcurrencyTimestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportDealerParameters", x => x.ExportDealerParameterId);
                    table.ForeignKey(
                        name: "FK_ExportDealerParameters_ExportDealers_ExportDealerId",
                        column: x => x.ExportDealerId,
                        principalTable: "ExportDealers",
                        principalColumn: "ExportDealerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExportDealerParameters_LayoutFields_LayoutFieldId",
                        column: x => x.LayoutFieldId,
                        principalTable: "LayoutFields",
                        principalColumn: "LayoutFieldId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExportTrackingDealer",
                columns: table => new
                {
                    ExportTrackingDealerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExportTrackingId = table.Column<int>(type: "int", nullable: false),
                    DealerId = table.Column<int>(type: "int", nullable: false),
                    VehicleCount = table.Column<int>(type: "int", nullable: false),
                    PhotoCount = table.Column<short>(type: "smallint", nullable: false),
                    ConcurrencyTimestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportTrackingDealer", x => x.ExportTrackingDealerId);
                    table.ForeignKey(
                        name: "FK_ExportTrackingDealer_ExportTracking_ExportTrackingId",
                        column: x => x.ExportTrackingId,
                        principalTable: "ExportTracking",
                        principalColumn: "ExportTrackingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("18b6e930-29db-4c03-88e9-840adf59f2f7"), "154c39c6-5f66-4ac0-9b88-d32534a981b9", "ContentManager", "ContentManager" },
                    { new Guid("558669b9-49a9-4520-90b8-51ba5b12c33e"), "7a2d3ef7-8c92-476f-a6ed-71a892bc7baf", "ProjectManager", "ProjectManager" },
                    { new Guid("9770d744-5c62-4d76-a4ef-163f94b33dad"), "763822b8-14e1-4448-b38d-2aa3fe2c5bdc", "SuperAdmin", "SuperAdmin" },
                    { new Guid("b67f4c23-5886-41ee-bbbb-6ae377f8f2ad"), "9af07178-2cdf-4775-a1a3-69b06b621504", "ProjectViewer", "ProjectViewer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("c9db7b0d-5889-4a71-b1a9-cf59ef2fa4be"), 0, "e201f36d-0576-450a-8467-2efde33fe9fa", "admin@test.com", true, "Admin", "Admin", false, null, "ADMIN@TEST.COM", "ADMIN", "AQAAAAEAACcQAAAAEMWrQksXUl1GMmbgwXq6oXsdRfI6WGkOH7wnjxjwrh8j60DJK5EGSQgZkIlp3sswzg==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "ContentBlocks",
                columns: new[] { "Id", "AllowedTokens", "Description", "IsPage", "Slug", "Title", "Value" },
                values: new object[,]
                {
                    { new Guid("2adc9376-95bf-4626-bd2c-02d570796efb"), "[{\"Token\":\"passwordResetUrl\",\"Description\":\"The URL for the user to reset their password\"}]", "The text that appears in a password reset message", false, "password-reset-email", "Reset Your Password", "To reset your account, follow this link: %passwordResetUrl%" },
                    { new Guid("59b06f2a-ab17-4f91-bf0f-1ce493ac22bd"), null, "", true, "placeholder", "Placeholder", "This is a placeholder page. The underlying functionality has not yet been implemented." },
                    { new Guid("ab8b109b-15c6-4893-be8a-e5d84a9661ee"), null, "The text that appears on the About page", true, "about", "About Us", "About us..." },
                    { new Guid("ce03a2df-e9db-424a-bb75-425d7ce0bd4e"), null, "Content that appears on the Home/Dashboard page", false, "dashboard", "Hello", "Hello, world. Or whoever else is here. This content is editable within the app." },
                    { new Guid("fac02dfe-ad10-41d4-ba52-ffb5461c23f0"), null, "The help page that appears in the top nav", true, "help", "Help!", "Need help? Don't we all." }
                });

            migrationBuilder.InsertData(
                table: "EncryptionType",
                columns: new[] { "EncryptionTypeId", "Description" },
                values: new object[,]
                {
                    { (short)1, "Explicit FTP over TLS" },
                    { (short)2, "Plain FTP" }
                });

            migrationBuilder.InsertData(
                table: "LayoutDataSourceType",
                columns: new[] { "LayoutDataSourceTypeId", "Description" },
                values: new object[,]
                {
                    { (short)1, "Layout Fields" },
                    { (short)2, "Stored Procedure" }
                });

            migrationBuilder.InsertData(
                table: "LayoutFieldType",
                columns: new[] { "LayoutFieldTypeId", "Description" },
                values: new object[,]
                {
                    { (short)1, "Database Field" },
                    { (short)2, "Parameter" }
                });

            migrationBuilder.InsertData(
                table: "OutputFormatType",
                columns: new[] { "OutputFormatTypeId", "Description" },
                values: new object[,]
                {
                    { (short)1, "Comma-Separated (CSV)" },
                    { (short)2, "Tab-Delimited (TAB)" },
                    { (short)3, "Pipe-Delimited" }
                });

            migrationBuilder.InsertData(
                table: "ProtocolType",
                columns: new[] { "ProtocolTypeId", "Description" },
                values: new object[,]
                {
                    { (short)1, "Plain FTP" },
                    { (short)2, "FTP+SSH" }
                });

            migrationBuilder.InsertData(
                table: "TransferModeType",
                columns: new[] { "TransferModeTypeId", "Description" },
                values: new object[,]
                {
                    { (short)1, "Active" },
                    { (short)2, "Passive" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Id" },
                values: new object[,]
                {
                    { new Guid("18b6e930-29db-4c03-88e9-840adf59f2f7"), new Guid("c9db7b0d-5889-4a71-b1a9-cf59ef2fa4be"), new Guid("d6d92b69-c456-41b5-af35-b6ccf03baf5d") },
                    { new Guid("558669b9-49a9-4520-90b8-51ba5b12c33e"), new Guid("c9db7b0d-5889-4a71-b1a9-cf59ef2fa4be"), new Guid("fd9b2c48-4094-4325-bb9d-3cf57f5e46cc") },
                    { new Guid("9770d744-5c62-4d76-a4ef-163f94b33dad"), new Guid("c9db7b0d-5889-4a71-b1a9-cf59ef2fa4be"), new Guid("841ad451-558f-4906-a4c5-7a075b134047") },
                    { new Guid("b67f4c23-5886-41ee-bbbb-6ae377f8f2ad"), new Guid("c9db7b0d-5889-4a71-b1a9-cf59ef2fa4be"), new Guid("11e5b2b6-efa1-44aa-8b29-359cd517a559") }
                });

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "DestinationId", "EncryptionTypeId", "FtpHost", "FtpPassword", "FtpRemoteDir", "FtpUsername", "IncludeHeaders", "Name", "OneFilePerDealer", "OutputFileName", "OutputFormatTypeId", "ProtocolTypeId", "SSHKeyFileName", "SendPhotosInZip", "SshFilePassword", "SshKeyFileChecksum", "TransferModeTypeId", "UseQuotedFields", "ZipOutputFile", "dtmCreated", "dtmLastChanged" },
                values: new object[] { 1, (short)1, "vendor.windowstickers.biz", "somepassword", "/", "someuser", true, "Test Destination 1", false, "Vehicledata.txt", (short)2, (short)1, null, false, null, null, (short)1, true, false, new DateTime(2024, 1, 11, 20, 11, 4, 75, DateTimeKind.Local).AddTicks(8610), new DateTime(2024, 1, 11, 20, 11, 4, 75, DateTimeKind.Local).AddTicks(8642) });

            migrationBuilder.InsertData(
                table: "Layouts",
                columns: new[] { "LayoutId", "CertifiedOnly", "Description", "LayoutDataSourceTypeId", "MakesList", "Name", "NewVehicles", "ProductsList", "StoredProcedureName", "UsedVehicles", "WarrantiesList", "dtmCreated" },
                values: new object[] { 1, null, null, (short)1, null, "Sample Layout 1", null, null, null, null, null, new DateTime(2024, 1, 11, 20, 11, 4, 75, DateTimeKind.Local).AddTicks(8654) });

            migrationBuilder.InsertData(
                table: "Exports",
                columns: new[] { "ExportId", "DestinationId", "LayoutId", "Name", "RunTimeOne", "RunTimeTwo", "dtmCreated", "dtmLastChanged" },
                values: new object[] { 1, 1, 1, "Sample Export 1", new TimeSpan(0, 0, 0, 0, 0), null, new DateTime(2024, 1, 11, 20, 11, 4, 75, DateTimeKind.Local).AddTicks(8668), new DateTime(2024, 1, 11, 20, 11, 4, 75, DateTimeKind.Local).AddTicks(8670) });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_Id",
                table: "AspNetUserRoles",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContentBlocks_Slug",
                table: "ContentBlocks",
                column: "Slug");

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_EncryptionTypeId",
                table: "Destinations",
                column: "EncryptionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_OutputFormatTypeId",
                table: "Destinations",
                column: "OutputFormatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_ProtocolTypeId",
                table: "Destinations",
                column: "ProtocolTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_TransferModeTypeId",
                table: "Destinations",
                column: "TransferModeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportDealerParameters_ExportDealerId",
                table: "ExportDealerParameters",
                column: "ExportDealerId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportDealerParameters_LayoutFieldId",
                table: "ExportDealerParameters",
                column: "LayoutFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportDealers_ExportId",
                table: "ExportDealers",
                column: "ExportId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportDealers_ExportId_DealerId",
                table: "ExportDealers",
                columns: new[] { "ExportId", "DealerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Exports_DestinationId",
                table: "Exports",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Exports_LayoutId",
                table: "Exports",
                column: "LayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportTracking_ExportId",
                table: "ExportTracking",
                column: "ExportId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportTrackingDealer_ExportTrackingId_DealerId",
                table: "ExportTrackingDealer",
                columns: new[] { "ExportTrackingId", "DealerId" });

            migrationBuilder.CreateIndex(
                name: "IX_ExternalCredentials_ApplicationUserId",
                table: "ExternalCredentials",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobItems_JobId",
                table: "JobItems",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_Created",
                table: "Jobs",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_LayoutFields_LayoutFieldTypeId",
                table: "LayoutFields",
                column: "LayoutFieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LayoutFieldsMap_LayoutFieldId",
                table: "LayoutFieldsMap",
                column: "LayoutFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_LayoutFieldsMap_LayoutId",
                table: "LayoutFieldsMap",
                column: "LayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Layouts_LayoutDataSourceTypeId",
                table: "Layouts",
                column: "LayoutDataSourceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ContentBlocks")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ContentBlocksHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropTable(
                name: "ExportDealerParameters");

            migrationBuilder.DropTable(
                name: "ExportTrackingDealer");

            migrationBuilder.DropTable(
                name: "ExternalCredentials");

            migrationBuilder.DropTable(
                name: "IdentityUserRole<long>");

            migrationBuilder.DropTable(
                name: "JobItems")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "JobItemsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropTable(
                name: "LayoutFieldsMap");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ExportDealers");

            migrationBuilder.DropTable(
                name: "ExportTracking");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Jobs")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "JobsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropTable(
                name: "LayoutFields");

            migrationBuilder.DropTable(
                name: "Exports")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ExportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropTable(
                name: "LayoutFieldType");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.DropTable(
                name: "Layouts");

            migrationBuilder.DropTable(
                name: "EncryptionType");

            migrationBuilder.DropTable(
                name: "OutputFormatType");

            migrationBuilder.DropTable(
                name: "ProtocolType");

            migrationBuilder.DropTable(
                name: "TransferModeType");

            migrationBuilder.DropTable(
                name: "LayoutDataSourceType");
        }
    }
}
