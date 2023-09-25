using VehicleExport.App.Models.Data.Accounts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VehicleExport.App.Models.Data;
using VehicleExport.App.Models.Data.Content;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Builder;
using VehicleExport.App.Models.Data.Donors;
using VehicleExport.App.Models;
using VehicleExport.Core.Models;
using Newtonsoft.Json;
using VehicleExport.App.Models.Data.Jobs;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Microsoft.EntityFrameworkCore.DataEncryption.Providers;
using Microsoft.Extensions.Configuration;
using VehicleExport.Core.Utilities;
using VehicleExport.App.Models.Data.Destinations;
using VehicleExport.App.Models.Data.DatabaseFields;
using VehicleExport.App.Models.Data.Layouts;
using VehicleExport.App.Models.Data.Exports;
using VehicleExport.App.Models.Data.LayoutFields;
using VehicleExport.App.Models.Data.ExportDealers;
using VehicleExport.App.Models.Data.LayoutFieldsMap;
using VehicleExport.App.Models.Data.MinorEntity;
using VehicleExport.App.Models.Data.ExportDealerParameters;
using System.Security.Cryptography;

namespace VehicleExport.App.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, IdentityUserClaim<Guid>, ApplicationUserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        private readonly IEncryptionProvider _encryptionProvider;
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ExternalCredential> ExternalCredentials { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

        public DbSet<ContentBlock> ContentBlocks { get; set; }


        public DbSet<DatabaseField> DatabaseFields { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<ExportDealerParameter> ExportDealerParameters { get; set; }
        public DbSet<ExportDealer> ExportDealers { get; set; }
        public DbSet<Export> Exports { get; set; }
        public DbSet<ExportTracking> ExportTracking { get; set; }
        public DbSet<ExportTrackingDealer> ExportTrackingDealer { get; set; }
        public DbSet<LayoutField> LayoutFields { get; set; }
        public DbSet<LayoutFieldMap> LayoutFieldMap { get; set; }
        public DbSet<Layout> Layouts { get; set; }
        public DbSet<ProtocolType> ProtocolTypes { get; set; }
        public DbSet<OutputFormatType> OutputFormatTypes { get; set; }
        public DbSet<EncryptionType> EncryptionTypes { get; set; }
        public DbSet<EncryptionProtocolType> EncryptionProtocolTypes { get; set; }
        public DbSet<LayoutDataSourceType> LayoutDataSourceTypes { get; set; }


        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobItem> JobItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            string hexEncryptionKey = configuration.GetValue<string>("EncryptionKey");
            string hexEncryptionIV = configuration.GetValue<string>("EncryptionIV");

            byte[] encryptionKey = EncryptionUtilities.StringToByteArray(hexEncryptionKey);
            byte[] encryptionIV = EncryptionUtilities.StringToByteArray(hexEncryptionIV);

            _encryptionProvider = new AesProvider(encryptionKey, encryptionIV);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UseEncryption(_encryptionProvider);

            // ==============================================================
            /* Accounts */

            modelBuilder.Entity<ExternalCredential>()
                .HasOne(x => x.ApplicationUser)
                .WithMany(x => x.ExternalCredentials)
                .HasForeignKey(x => x.ApplicationUserId);

            modelBuilder.Entity<IdentityUserRole<long>>()
                .HasKey(x => new { x.UserId, x.RoleId });

            modelBuilder.Entity<ApplicationUserRole>()
                .HasIndex(x => x.Id)
                .IsUnique();

            modelBuilder.Entity<ApplicationUserRole>()
                .HasOne(x => x.ApplicationRole)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId)
                .IsRequired();

            modelBuilder.Entity<ApplicationUserRole>()
                .HasOne(x => x.ApplicationUser)
                .WithMany(x => x.Roles)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            // ==============================================================
            /* Content */

            modelBuilder.Entity<ContentBlock>()
                .ToTable("ContentBlocks", b => b.IsTemporal());

            modelBuilder.Entity<ContentBlock>()
                .HasIndex(x => x.Slug)
                .IsUnique(false);

            modelBuilder.Entity<ContentBlock>()
                .Property(x => x.AllowedTokens)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<AllowedToken>>(v)
                );

            // ==============================================================
            /* Database Fields */

            modelBuilder.Entity<DatabaseField>()
                .ToTable("DatabaseFields");

            // ==============================================================
            /* Destinations */

            modelBuilder.Entity<Destination>()
                .ToTable("Destinations");

            modelBuilder.Entity<Destination>()
                .HasOne(x => x.ProtocolType)
                .WithMany(x => x.Destinations)
                .HasForeignKey(x => x.ProtocolTypeId);

            modelBuilder.Entity<Destination>()
                .HasOne(x => x.OutputFormatType)
                .WithMany(x => x.Destinations)
                .HasForeignKey(x => x.OutputFormatTypeId);

            modelBuilder.Entity<Destination>()
                .HasOne(x => x.EncryptionType)
                .WithMany(x => x.Destinations)
                .HasForeignKey(x => x.EncryptionTypeId);
            modelBuilder.Entity<Destination>()
                .HasOne(x => x.EncryptionProtocolType)
                .WithMany(x => x.Destinations)
                .HasForeignKey(x => x.EncryptionProtocolTypeId);

            // ==============================================================
            // Exports

            modelBuilder.Entity<Export>()
                .ToTable("Exports", b => b.IsTemporal());

            modelBuilder.Entity<Export>()
                .HasOne(x => x.Layout)
                .WithMany(x => x.Exports)
                .HasForeignKey(x => x.LayoutId);

            modelBuilder.Entity<Export>()
                .HasOne(x => x.Destination)
                .WithMany(x => x.Exports)
                .HasForeignKey(x => x.DestinationId);

            // ==============================================================
            // Export Dealers 

            modelBuilder.Entity<ExportDealer>()
                .ToTable("ExportDealers");

            // For references to EXPORT table
            modelBuilder.Entity<ExportDealer>()
                .HasIndex(x => x.ExportId);

            // For selects by EXPORT and VSO Dealer
            modelBuilder.Entity<ExportDealer>()
                .HasIndex(x => new { x.ExportId, x.DealerId });

            //modelBuilder.Entity<ExportDealer>()
            //                .HasOne(x => x.Export)
            //                .WithMany(x => x.ExportDealer)
            //                .HasForeignKey(x => x.ExportId)
            //                .OnDelete(DeleteBehavior.NoAction);

            // ==============================================================
            // Export Dealer Parameters

            modelBuilder.Entity<ExportDealerParameter>()
                .ToTable("ExportDealerParameters");


            // ==============================================================
            // ExportTrackingDealer

            modelBuilder.Entity<ExportTrackingDealer>()
                .ToTable("ExportTrackingDealer");

            modelBuilder.Entity<ExportTrackingDealer>()
                .HasIndex(k => new { k.ExportTrackingId, k.DealerId });

            // ==============================================================
            // ExportTracking

            modelBuilder.Entity<ExportTracking>()
                .ToTable("ExportTracking");

            modelBuilder.Entity<ExportTracking>()
                .HasIndex(x => x.ExportId);

            // ==============================================================
            // Layouts

            modelBuilder.Entity<Layout>()
                .ToTable("Layouts");

            // ==============================================================
            //LayoutFields

            modelBuilder.Entity<LayoutField>()
                .ToTable("LayoutFields");

            modelBuilder.Entity<LayoutField>()
                .HasIndex(x => x.LayoutId);

            modelBuilder.Entity<LayoutField>()
                .HasIndex(x => x.DatabaseFieldId);

            modelBuilder.Entity<LayoutField>()
                .HasOne(x => x.LayoutFieldType)
                .WithMany(x => x.LayoutFields)
                .HasForeignKey(x => x.LayoutFieldTypeId);

            // ==============================================================
            //LayoutFieldsMap

            modelBuilder.Entity<LayoutFieldMap>()
                .ToTable("LayoutFieldsMap");

            // ==============================================================
            //Minor Entity Tables

            modelBuilder.Entity<ProtocolType>()
                .ToTable("ProtocolType");
            modelBuilder.Entity<LayoutFieldType>()
                .ToTable("LayoutFieldType");
            modelBuilder.Entity<OutputFormatType>()
                .ToTable("OutputFormatType");
            modelBuilder.Entity<EncryptionType>()
                .ToTable("EncryptionType");
            modelBuilder.Entity<EncryptionProtocolType>()
                .ToTable("EncryptionProtocolType");
            modelBuilder.Entity<LayoutDataSourceType>()
                .ToTable("LayoutDataSourceType");

            // ==============================================================
            /* Jobs */

            modelBuilder.Entity<Job>()
                .ToTable("Jobs", b => b.IsTemporal());

            modelBuilder.Entity<JobItem>()
                .ToTable("JobItems", b => b.IsTemporal());

            modelBuilder.Entity<JobItem>()
                .HasOne(x => x.Job)
                .WithMany(x => x.JobItems)
                .HasForeignKey(x => x.JobId);

            modelBuilder.Entity<Job>()
                .HasIndex(x => x.Created);

            /* Seed Data */

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // If you're running this for the first time and need to seed this data, remove the conditional compilation directive below.
            //#if INITIAL_RUN
            SeedRoles(modelBuilder);
            SeedUsers(modelBuilder);
            SeedContent(modelBuilder);
            SeedAppData(modelBuilder);
            //#endif
        }

        private static class RoleIds
        {
            public static Guid SuperAdmin = Guid.Parse("9770d744-5c62-4d76-a4ef-163f94b33dad");
            public static Guid ProjectManager = Guid.Parse("558669b9-49a9-4520-90b8-51ba5b12c33e");
            public static Guid ProjectViewer = Guid.Parse("b67f4c23-5886-41ee-bbbb-6ae377f8f2ad");
            public static Guid ContentManager = Guid.Parse("18b6e930-29db-4c03-88e9-840adf59f2f7");
        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole()
            {
                Id = RoleIds.SuperAdmin,
                Name = ApplicationRoleNames.SuperAdmin,
                NormalizedName = ApplicationRoleNames.SuperAdmin
            });

            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole()
            {
                Id = RoleIds.ProjectManager,
                Name = ApplicationRoleNames.ProjectManager,
                NormalizedName = ApplicationRoleNames.ProjectManager
            });

            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole()
            {
                Id = RoleIds.ProjectViewer,
                Name = ApplicationRoleNames.ProjectViewer,
                NormalizedName = ApplicationRoleNames.ProjectViewer
            });

            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole()
            {
                Id = RoleIds.ContentManager,
                Name = ApplicationRoleNames.ContentManager,
                NormalizedName = ApplicationRoleNames.ContentManager
            });
        }

        private void SeedUsers(ModelBuilder modelBuilder)
        {
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            var id0 = Guid.Parse("c9db7b0d-5889-4a71-b1a9-cf59ef2fa4be");
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = id0,
                UserName = "admin",
                NormalizedUserName = "admin".ToUpper(),
                Email = "admin@test.com",
                NormalizedEmail = "admin@test.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = passwordHasher.HashPassword(null, "abcd1234"),
                SecurityStamp = string.Empty,
                FirstName = "Admin",
                LastName = "Admin"
            });

            foreach (Guid userId in new Guid[] { id0 })
            {
                foreach (Guid roleId in new Guid[] { RoleIds.SuperAdmin, RoleIds.ProjectManager, RoleIds.ProjectViewer, RoleIds.ContentManager })
                {
                    modelBuilder.Entity<ApplicationUserRole>().HasData(new ApplicationUserRole()
                    {
                        Id = Guid.NewGuid(),
                        RoleId = roleId,
                        UserId = userId
                    });
                }
            }

        }

        private void SeedContent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContentBlock>().HasData(new ContentBlock()
            {
                Id = Guid.NewGuid(),
                Slug = "password-reset-email",
                IsPage = false,
                Description = "The text that appears in a password reset message",
                Title = "Reset Your Password",
                Value = @"To reset your account, follow this link: %passwordResetUrl%",
                AllowedTokens = new List<AllowedToken>()
                {
                    new AllowedToken()
                    {
                        Token = "passwordResetUrl",
                        Description = "The URL for the user to reset their password"
                    }
                }
            });

            modelBuilder.Entity<ContentBlock>().HasData(new ContentBlock()
            {
                Id = Guid.NewGuid(),
                Slug = "about",
                IsPage = true,
                Description = "The text that appears on the About page",
                Title = "About Us",
                Value = "About us..."
            });

            modelBuilder.Entity<ContentBlock>().HasData(new ContentBlock()
            {
                Id = Guid.NewGuid(),
                Slug = "placeholder",
                IsPage = true,
                Description = "",
                Title = "Placeholder",
                Value = "This is a placeholder page. The underlying functionality has not yet been implemented."
            });

            modelBuilder.Entity<ContentBlock>().HasData(new ContentBlock()
            {
                Id = Guid.NewGuid(),
                Slug = "dashboard",
                IsPage = false,
                Description = "Content that appears on the Home/Dashboard page",
                Title = "Hello",
                Value = "Hello, world. Or whoever else is here. This content is editable within the app."
            });

            modelBuilder.Entity<ContentBlock>().HasData(new ContentBlock()
            {
                Id = Guid.NewGuid(),
                Slug = "help",
                IsPage = true,
                Description = "The help page that appears in the top nav",
                Title = "Help!",
                Value = "Need help? Don't we all."
            });
        }

        private void SeedAppData(ModelBuilder modelBuilder)
        {
            var alphabetId = Guid.NewGuid();
            var northwoodsId = Guid.NewGuid();
            var adminId = Guid.Parse("c9db7b0d-5889-4a71-b1a9-cf59ef2fa4be");

            // ProtocolType
            modelBuilder.Entity<ProtocolType>().HasData(new ProtocolType()
            {
                ProtocolTypeId = 1,
                Description = "Plain FTP",
            });
            modelBuilder.Entity<ProtocolType>().HasData(new ProtocolType()
            {
                ProtocolTypeId = 2,
                Description = "FTP+SSH",
            });

            // LayoutFieldType
            modelBuilder.Entity<LayoutFieldType>().HasData(new LayoutFieldType()
            {
                LayoutFieldTypeId = 1,
                Description = "Database Field",
            });
            modelBuilder.Entity<LayoutFieldType>().HasData(new LayoutFieldType()
            {
                LayoutFieldTypeId = 2,
                Description = "Parameter",
            });

            modelBuilder.Entity<LayoutFieldType>().HasData(new LayoutFieldType()
            {
                LayoutFieldTypeId = 3,
                Description = "Placeholder",
            });

            // OutputFormatType
            modelBuilder.Entity<OutputFormatType>().HasData(new OutputFormatType()
            {
                OutputFormatTypeId = 1,
                Description = "Comma-Separated (CSV)",
            });
            modelBuilder.Entity<OutputFormatType>().HasData(new OutputFormatType()
            {
                OutputFormatTypeId = 2,
                Description = "Tab-Delimited (TAB)",
            });
            modelBuilder.Entity<OutputFormatType>().HasData(new OutputFormatType()
            {
                OutputFormatTypeId = 3,
                Description = "Pipe-Delimited",
            });

            modelBuilder.Entity<EncryptionType>().HasData(new EncryptionType()
            {
                EncryptionTypeId = 1,
                Description = "Active",
            });
            modelBuilder.Entity<EncryptionType>().HasData(new EncryptionType()
            {
                EncryptionTypeId = 2,
                Description = "Passive",
            });

            modelBuilder.Entity<EncryptionProtocolType>().HasData(new EncryptionProtocolType()
            {
                EncryptionProtocolTypeId = 1,
                Description = "Explicit FTP over TLS",
            });
            modelBuilder.Entity<EncryptionProtocolType>().HasData(new EncryptionProtocolType()
            {
                EncryptionProtocolTypeId = 2,
                Description = "Plain FTP",
            });

            modelBuilder.Entity<LayoutDataSourceType>().HasData(new LayoutDataSourceType()
            {
                LayoutDataSourceTypeId = 1,
                Description = "Layout Fields",
            });
            modelBuilder.Entity<LayoutDataSourceType>().HasData(new LayoutDataSourceType()
            {
                LayoutDataSourceTypeId = 2,
                Description = "Stored Procedure",
            });

            // Destinations
            modelBuilder.Entity<Destination>().HasData(new Destination()
            {
                DestinationId = 1,
                Name = "Test Destination 1",
                FtpHost = "vendor.windowstickers.biz",
                FtpUsername = "someuser",
                FtpPassword = "somepassword",
                FtpRemoteDir = "/",
                ProtocolTypeId = 1,
                OutputFormatTypeId = 2,
                EncryptionTypeId = 1,
                EncryptionProtocolTypeId = 1,
                UseQuotedFields = true,
                IncludeHeaders = true,
                OutputFileName = "Vehicledata.txt",
                ZipOutputFile = false,
                OneFilePerDealer = false,
                SendPhotosInZip = false,
                dtmCreated = DateTime.Now,
                dtmLastChanged = DateTime.Now
            });

            // Layout
            modelBuilder.Entity<Layout>().HasData(new Layout()
            {
                LayoutId = 1,
                Name = "Sample Layout 1",
                LayoutDataSourceTypeId = 1,
                dtmCreated = DateTime.Now
            });

            //Exports
            modelBuilder.Entity<Export>().HasData(new Export()
            {
                ExportId = 1,
                Name = "Sample Export 1",
                LayoutId = 1,
                DestinationId = 1,
                RunTimeOne = new TimeSpan(),
                dtmCreated = DateTime.Now,
                dtmLastChanged = DateTime.Now
            });
        }
    }
}

