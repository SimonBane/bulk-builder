using BulkBuilder.Application.Common.RequestInterceptors;
using BulkBuilder.Application.Users;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Models;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BulkBuilder.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(ExerciseDto).Assembly;

            services.AddScoped<IUserContext, UserContext>();

            services.AddMemoryCache();

            services.AddAutoMapper(assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UserContextBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UserExistenceCheckBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));

            services.AddMediatR(assembly);
            services.AddFluentValidation(opts => opts.RegisterValidatorsFromAssembly(assembly));

            return services;
        }

        public static void UseErrorHandling(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
