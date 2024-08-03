using Host.Common.Constants;
using Host.DB.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using Serilog;

namespace Host.DB
{
    public static class DependencyInjection
    {
        /// <summary>
        /// <para>Base on sqlProvider, the context will use/apply the migrations of their onwed.</para>
        /// <para>Set startups project GH.Gateway (or what ever but MUST call this AddPersistence method in the program (startup)</para>
        /// <para>Also set Target Project based on Proivider. Example with SQLServer provider, target project must be GH.DB.SQLServer.</para>
        /// <para>Add-Migration MyMigration -Args "--provider SqlServer"</para> 
        /// <para>cd to root folder: dotnet ef migrations add User --startup-project .\GH.AdminPortal\ --project .\GH.DB.SQLServer</para> 
        /// <para>cd to root folder: dotnet ef migrations add User --startup-project .\GH.AdminPortal\ --project .\GH.DB.MySQL</para> 
        /// 
        /// <para>Add-Migration UserEntities</para>
        /// <para>In the LaunchSettings.json commandLineArgs provided the SQL Provider</para>
        /// <para>When running add migration cli, REMEMBER the ENVIRONMENT VARS</para>
        /// <para>When running add migration cli, REMEMBER the ENVIRONMENT VARS DB_Provider and GH_DB_CONNECTION/GH_DB_SQLSERVER_CONNECTION</para>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="sqlProvider">Mysql, SqlServer</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            try
            {
                var sqlProvider = Environment.GetEnvironmentVariable(EnvironmentConstants.DB_Provider);
                
                services.AddDbContext<HostContext>(options =>
                _ = sqlProvider switch
                {
                    "Mysql" => options.UseMySql(Environment.GetEnvironmentVariable(EnvironmentConstants.GH_DB_CONNECTION), ServerVersion.Parse("8.0.0"), x => x.MigrationsAssembly("Host.DB.MySQL")),

                    _ => throw new Exception($"Unsupported provider: {sqlProvider}")
                });

                //services.RegisterAssemblyPublicNonGenericClasses()
                //.Where(c => c.Name.EndsWith("Repository"))
                //.AsPublicImplementedInterfaces(ServiceLifetime.Scoped);


                //services.RegisterAssemblyPublicNonGenericClasses()
                // .Where(c => c.Name.EndsWith("UnitOfWork"))
                // .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

                return services;
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return services;
            }
            finally
            {
            }
        }
    }
}
