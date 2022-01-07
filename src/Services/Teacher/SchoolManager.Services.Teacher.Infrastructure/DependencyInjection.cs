using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolManager.Services.Teacher.Infrastructure.Context;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using SchoolManager.Services.Teacher.Domain.Teacher.Interfaces;
using SchoolManager.Services.Teacher.Domain.Teacher.Services;
using System;
using SchoolManager.Services.Teacher.Application.Teacher.Interfaces;
using SchoolManager.Services.Teacher.Application.Teacher;
using SchoolManager.Services.Teacher.Infrastructure.Repositories;

namespace SchoolManager.Services.Teacher.Infrastructure
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TeacherAPI", Version = "v1" });
            });
            //services.AddAuthentication("Bearer")
            //    .AddJwtBearer("Bearer", options =>
            //    {
            //        options.Authority = "https://localhost:44398";
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateAudience = false
            //        };
            //    });

            //services.AddAuthorization(options => {
            //    options.AddPolicy("ApiScope", policy =>
            //    {
            //        policy.RequireAuthenticatedUser();
            //        policy.RequireClaim("scope", "SchoolManager");

            //    });
            //});

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Manage.Services.Teacher", Version = "v1" });
            //    c.EnableAnnotations();
            //    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //    {
            //        Description = @"Enter 'Bearer' [space] and your token",
            //        Name = "Authorization",
            //        In = ParameterLocation.Header,
            //        Type = SecuritySchemeType.ApiKey,
            //        Scheme = "Bearer"
            //    });

            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
            //        {
            //            new OpenApiSecurityScheme
            //            {
            //                Reference = new OpenApiReference
            //                {
            //                    Type=ReferenceType.SecurityScheme,
            //                    Id="Bearer"
            //                },
            //                Scheme="oauth2",
            //                Name="Bearer",
            //                In=ParameterLocation.Header
            //            },
            //            new List<string>()
            //        }
            //    });
            //});
            #endregion

            services.AddControllers();
            services.AddResponseCompression();

            services.AddHttpClient<ICourseService, CourseService>(u => u.BaseAddress =
                          new Uri(configuration["ServiceUrls:CourseAPI"]));

            services.AddScoped<ITeacherAppService, TeacherAppService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<DbContext, ApplicationDbContext>();
            services.AddScoped<ICourseCacheRepository, CourseCacheRepository>();

            services.AddStackExchangeRedisCache( options =>
            {
                options.Configuration = "localhost:6379";
            });

            return services;
        }
    }
}
