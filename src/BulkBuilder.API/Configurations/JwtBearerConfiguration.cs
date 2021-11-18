using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using BulkBuilder.Application.Common.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace BulkBuilder.API.Configurations
{
    public static class JwtBearerConfiguration
    {
        public static void UseJwtBearerAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = configuration["AuthenticationConfig:Authority"];
                    options.Audience = configuration["AuthenticationConfig:Audience"];
                });
        }
    }
}