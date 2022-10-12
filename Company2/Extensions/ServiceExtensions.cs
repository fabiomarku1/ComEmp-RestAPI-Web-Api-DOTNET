using Company2.Presentation.Controllers;
using Contracts;
using LoggerService;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;
using Service.Contracts;

namespace Company2.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {
            });

        public static void ConfigureLoggerService(this IServiceCollection services) =>
           services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static void ConfigureVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.ApiVersionReader = new HeaderApiVersionReader("api-version");
                opt.Conventions.Controller<CompaniesController>()
                    .HasApiVersion(new ApiVersion(1, 0));
                opt.Conventions.Controller<CompaniesV2Controller>()
                    .HasDeprecatedApiVersion(new ApiVersion(2, 0));
            });
        }
        public static void ConfigureResponseCaching(this IServiceCollection services) => services.AddResponseCaching();

        public static void ConfigureHtppCacheHeaders(this IServiceCollection services) =>
            services.AddHttpCacheHeaders((expOption) =>
            {
                expOption.MaxAge = 65;
                expOption.CacheLocation = CacheLocation.Private;
            },

        (validateOpt) =>
        {
            validateOpt.MustRevalidate = true;
        }
            );

    }
}
