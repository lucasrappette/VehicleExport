using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VehicleExport.App.DAL;
using VehicleExport.App.Models.Data;
using VehicleExport.App.Models.Data.Accounts;
using VehicleExport.App.Models.Data.Content;
using VehicleExport.App.Models.Data.Content.Validators;
using VehicleExport.App.Models.Data.Donors.Validators;
using VehicleExport.App.Models.Data.Jobs;
using VehicleExport.App.Models.Data.Jobs.Validators;
using VehicleExport.App.Models.Service.WorkItems.Echo;
using VehicleExport.App.Services.Data;
using VehicleExport.App.Services.Data.Accounts;
using VehicleExport.App.Services.Data.Content;
using VehicleExport.App.Services.Data.Jobs;
using VehicleExport.App.Services.WorkItems;
using System;
using VehicleExport.App.Models.Data.Exports;
using VehicleExport.App.Services.Data.Exports;
using VehicleExport.App.Services.Data.Layouts;
using VehicleExport.App.Models.Data.Layouts;
using VehicleExport.App.Services.Data.Destinations;
using VehicleExport.App.Models.Data.Destinations;
using VehicleExport.App.Models.Data.Exports.Validators;
using VehicleExport.App.Models.Data.Layouts.Validators;
using VehicleExport.App.Models.Data.Destinations.Validators;
using VehicleExport.App.Models.Data.ExportDealerParameters;
using VehicleExport.App.Models.Data.ExportDealerParameters.Validators;
using VehicleExport.App.Models.Data.ExportDealers;
using VehicleExport.App.Models.Data.ExportDealers.Validators;
using VehicleExport.App.Models.Data.LayoutFields;
using VehicleExport.App.Models.Data.LayoutFields.Validators;
using VehicleExport.App.Models.Data.LayoutFieldsMap;
using VehicleExport.App.Models.Data.LayoutFieldsMap.Validators;
using VehicleExport.App.Services.Data.LayoutFields;
using VehicleExport.App.Models.Data.MinorEntity;
using VehicleExport.App.Services.Data.MinorEntity;
using VehicleExport.App.Models.Data.MinorEntity.Validators;

namespace VehicleExport.App
{
    public static class ServiceBuilder
    {
        /// <summary>
        /// Configures the EF database connection and identity. This is used in both the web and worker layer.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("Default"), 
                x =>
                {
                    x.CommandTimeout(300);
                }));

            // Add Identity
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }

        /// <summary>
        /// Configures the application services. This is used in both the web and worker layer.
        /// </summary>
        /// <param name="services"></param>
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddEntityServices();
            services.AddEntityValidators();
            services.AddWorkItemServices();

            services.AddHttpClient();

        }

        private static void AddTransientListReadWriteService<TDataModel, TId, TService>(this IServiceCollection services)
            where TDataModel : class, IEntity
            where TService : class, IEntityWriteService<TDataModel, TId>
        {
            services.AddTransient<IEntityListService<TDataModel>, TService>();
            services.AddTransient<IEntityReadService<TDataModel, TId>, TService>();
            services.AddTransient<IEntityWriteService<TDataModel, TId>, TService>();
            services.AddTransient<TService, TService>();
        }

        private static void AddTransientListReadService<TDataModel, TId, TService>(this IServiceCollection services)
            where TDataModel : class, IEntity
            where TService : class, IEntityReadService<TDataModel, TId>
        {
            services.AddTransient<IEntityListService<TDataModel>, TService>();
            services.AddTransient<IEntityReadService<TDataModel, TId>, TService>();
            services.AddTransient<TService, TService>();
        }

        private static void AddTransientListService<TDataModel, TService>(this IServiceCollection services)
            where TDataModel : class, IEntity
            where TService : class, IEntityListService<TDataModel>
        {
            services.AddTransient<IEntityListService<TDataModel>, TService>();
            services.AddTransient<TService, TService>();
        }

        public static void AddEntityServices(this IServiceCollection services)
        {
            services.AddTransientListReadWriteService<ApplicationUser, Guid, ApplicationUserService>();
            services.AddTransientListReadWriteService<ApplicationRole, Guid, ApplicationRoleService>();
            services.AddTransientListReadWriteService<ContentBlock, Guid, ContentBlockService>();
            services.AddTransient<ContentBlockService, ContentBlockService>();

            services.AddTransientListReadWriteService<Job, Guid, JobService>();
            services.AddTransientListReadWriteService<JobItem, Guid, JobItemService>();

            services.AddTransientListReadWriteService<Destination, int, DestinationService>();
            //services.AddTransientListReadWriteService<ExportDealerParameter, int, ExportDealerParameterService>();
            services.AddTransientListReadWriteService<Export, int, ExportService>();
            services.AddTransientListReadWriteService<ExportTracking, int, ExportTrackingService>();
            services.AddTransientListReadWriteService<LayoutField, int, LayoutFieldsService>();
            services.AddTransientListReadWriteService<Layout, int, LayoutService>();
            // Add AddTransientListReadService (ReadOnly) for three ME tables
            services.AddTransientListReadService<LayoutFieldType, short, LayoutFieldTypeService>();
            services.AddTransientListReadService<OutputFormatType, short, OutputFormatTypeService>();
            services.AddTransientListReadService<ProtocolType, short, ProtocolTypeService>();
            services.AddTransientListReadService<TransferModeType, short, TransferModeTypeService>();
            services.AddTransientListReadService<EncryptionType, short, EncryptionTypeService>();
            services.AddTransientListReadService<LayoutDataSourceType, short, LayoutDataSourceTypeService>();
        }

        public static void AddEntityValidators(this IServiceCollection services)
        {
            services.AddSingleton<IValidator<ApplicationUser>, ApplicationUserValidator>();
            services.AddSingleton<IValidator<ApplicationRole>, ApplicationRoleValidator>();
            services.AddSingleton<IValidator<ContentBlock>, ContentBlockValidator>();

            services.AddSingleton<IValidator<Job>, JobValidator>();
            services.AddSingleton<IValidator<JobItem>, JobItemValidator>();

            services.AddSingleton<IValidator<Destination>, DestinationValidator>();
            services.AddSingleton<IValidator<ExportDealerParameter>, ExportDealerParametersValidator>();
            services.AddSingleton<IValidator<ExportDealer>, ExportDealersValidator>();
            services.AddSingleton<IValidator<ExportTracking>, ExportTrackingValidator>();
            services.AddSingleton<IValidator<ExportTrackingDealer>, ExportTrackingDealerValidator>();
            services.AddSingleton<IValidator<Export>, ExportValidator>();
            services.AddSingleton<IValidator<LayoutField>, LayoutFieldsValidator>();
            services.AddSingleton<IValidator<LayoutFieldMap>, LayoutFieldsMapValidator>();
            services.AddSingleton<IValidator<Layout>, LayoutValidator>();
            // Add ME Tables
            services.AddSingleton<IValidator<LayoutFieldType>, LayoutFieldTypeValidator>();
            services.AddSingleton<IValidator<OutputFormatType>, OutputFormatTypeValidator>();
            services.AddSingleton<IValidator<ProtocolType>, ProtocolTypeValidator>();
            services.AddSingleton<IValidator<TransferModeType>, TransferModeTypeValidator>();
            services.AddSingleton<IValidator<EncryptionType>, EncryptionTypeValidator>();
            services.AddSingleton<IValidator<LayoutDataSourceType>, LayoutDataSourceTypeValidator>();
        }

        public static void AddWorkItemServices(this IServiceCollection services)
        {
            services.AddSingleton<IWorkItemService<EchoWorkItem>, WorkItemService<EchoWorkItem>>();

            services.AddTransient<ISecureWorkItemService<EchoWorkItem>, SecureWorkItemService<EchoWorkItem>>();
        }
    }
}
