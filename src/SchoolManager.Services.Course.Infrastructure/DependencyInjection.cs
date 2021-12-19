using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolManager.Services.Course.Infrastructure.Context;
using SchoolManager.Services.Course.Infrastructure.Repositories;
using SchoolManager.Services.Course.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SchoolManager.Services.Course.Domain.Services;
using Microsoft.AspNetCore.Builder;
using SchoolManager.Services.Course.Application.Course;
using SchoolManager.Services.Course.Application.Course.Interfaces;

namespace SchoolManager.Services.Course.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            
            services.AddDbContext<ApplicationDbContext>(
                    options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                )
            );

            #region Swagger
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:44398";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization(options => {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "bob");

                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Manage.Services.ShoppingCart", Version = "v1" });
                c.EnableAnnotations();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Enter 'Bearer' [space] and your token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            },
                            Scheme="oauth2",
                            Name="Bearer",
                            In=ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
            #endregion
           
            services.AddControllers();
            services.AddResponseCompression();

            #region DI
            #region DI Context
            services.AddScoped<DbContext, ApplicationDbContext>();
            #endregion
            #region DI AppService
            services.AddScoped<ICourseAppService, CourseAppService>();
            #endregion
            #region DI Service
            services.AddScoped<ICourseService, CourseService>();
            #endregion
            #region DI Repository
            services.AddScoped<ICourseRepository, CourseRepository>();
            #endregion
            #endregion

            return services;
        }
    }
}
