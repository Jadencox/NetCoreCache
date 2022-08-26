using Citms.Common.Mapping;
using NetCoreCache.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace NetCoreCache
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Build an <see cref="ExceptionManager"/> and add it in specified service collection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="Configuration">The delegate to build the <see cref="ExceptionManager"/>.</param>
        /// <returns>The current service collection.</returns>
        /// <exception cref="ArgumentNullException">The specified argument <paramref name="services"/> is null.</exception>
        /// <exception cref="ArgumentNullException">The specified argument <paramref name="Configuration"/> is null.</exception>
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration Configuration)
        {
            //Guard.ArgumentNotNull(services, "services");
            //Guard.ArgumentNotNull(Configuration, "Configuration");
            //EFCoreLocator.RegisterProviderRelate("Oracle.EntityFrameworkCore", EFCoreExtend.SqlGenerator.DBType.Oracle);


            //services.AddScoped(x => new DbConnectSource(GetConnectString(Configuration)));

            //Add module DbContext
            //services.AddDoCareDbContext<UserManageDbContext>(Configuration);

            services.AddDoCareDbContext<WorkStationDbContext>(Configuration);


            return services;
        }

        /// <summary>
        /// Oracle 11g Settings
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <param name="services"></param>
        /// <param name="Configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddDoCareDbContext<TContext>(this IServiceCollection services, IConfiguration Configuration) where TContext : DbContext
        {
            var connectString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<TContext>((service, options) => options.UseOracle(connectString, b => b.UseOracleSQLCompatibility("11")));

            var fields = typeof(TContext).GetRuntimeFields();
            foreach (var field in fields)
            {
                var fieldType = field.FieldType;
                if (fieldType.IsGenericType)
                {
                    var genericTypes = fieldType.GenericTypeArguments;
                    foreach (var genericType in genericTypes)
                    {
                        MappingResolver.CreateEntityMap(genericType);
                    }
                }
            }

            return services;
        }

        /// <summary>
        /// Oracle 11g Settings
        /// </summary>
        /// <param name="options"></param>
        /// <param name="configuration"></param>
        /// <param name="service"></param>
        /// <returns></returns>
        public static DbContextOptionsBuilder UseOracle11(this DbContextOptionsBuilder options, IConfiguration configuration, IServiceProvider service = null)
        {
            //if (service != null)
            //{
            //    var dbConnectSource = service.GetRequiredService<DbConnectSource>();
            //    var dbConnection = dbConnectSource.SqlConnection;
            //    return options.UseOracle(dbConnection, b => b.UseOracleSQLCompatibility("11"));
            //}
            var connectString = configuration.GetConnectionString("DefaultConnection");

            return options.UseOracle(connectString, b => b.UseOracleSQLCompatibility("11"));
            //return options.UseOracle(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
