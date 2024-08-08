using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System.Runtime.CompilerServices;

namespace Host.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
#if DEBUG
            services.AddCors(o => o.AddPolicy("AllowedAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
#endif

            services.RegisterAssemblyPublicNonGenericClasses()
             .Where(c => c.Name.EndsWith("Service"))
             .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);
            return services;
        }

        public static IServiceCollection ConstructApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.ReportApiVersions = true;
                opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                                new HeaderApiVersionReader("host-api-version"),
                                                                new MediaTypeApiVersionReader("host-api-version"));
            });

            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}
