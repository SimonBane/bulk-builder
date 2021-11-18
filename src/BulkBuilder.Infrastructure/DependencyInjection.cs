using System.Reflection;
using BulkBuilder.Application.Abstractions;
using BulkBuilder.Infrastructure.Repositories.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Abstractions;

namespace BulkBuilder.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<BulkDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(BulkDbContext).GetTypeInfo().Assembly.GetName()
                        .Name)));

            services.AddScoped<DbContext, BulkDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.Scan(scan => scan
                .FromAssembliesOf(typeof(BaseRepository<>))
                .AddClasses(f => f.AssignableTo(typeof(IRepository<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

            return services;
        }

        public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app, BulkDbContext context)
        {
            context.Database.Migrate();
            return app;
        }
    }
}