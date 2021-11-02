using System.Reflection;
using BulkBuilder.Application.Abstractions;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Data;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Data;
using BulkBuilder.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BulkBuilder.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BulkDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(BulkDbContext).GetTypeInfo().Assembly.GetName().Name)));

            services.AddScoped<DbContext, BulkDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<IWorkoutRepository, WorkoutRepository>();
            services.AddScoped<IWorkoutExerciseRepository, WorkoutExerciseRepository>();

            return services;
        }

        public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app, BulkDbContext context)
        {
            context.Database.Migrate();
            return app;
        }
    }
}
