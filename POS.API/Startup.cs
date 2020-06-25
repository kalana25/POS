using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using POS.DAL;
using POS.Core.General;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using POS.Core.DI;
using Microsoft.Extensions.Hosting;
using Microsoft.CodeAnalysis.Options;
using System.Text;
using Microsoft.OpenApi.Models;

namespace POS.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public AppSettings AppSettings { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            this.AppSettings = services.AddServiceCore(Configuration);
            services.AutoDIRegisterService();
            var autoMapper = new AutoMapper.MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
            });
            var mapper = autoMapper.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(AppSettings.ConnectionString.Development));

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 5;
            })
            .AddEntityFrameworkStores<DataBaseContext>()
            .AddDefaultTokenProviders();

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = AppSettings.Auth.Issuer,
                    ValidAudience = AppSettings.Auth.Audience,
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(AppSettings.Auth.Secret)
                        ),
                    ValidateIssuerSigningKey = true,
                };
            });


            services.AddMvc(options => {
                options.EnableEndpointRouting = false;
            });
            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            services.AddSwaggerGen(c =>
            {
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer",new string[0] }
                };
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme { 
                     Description = "JWT Authorization header using bearer scheme",
                     Name="Authorization",
                     In=ParameterLocation.Header,
                    Type =SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo{ Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("default");
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
                c.SwaggerEndpoint("/PosApi/swagger/v1/swagger.json", "API v1");
                c.RoutePrefix = string.Empty;
            });
            app.UseMvc();
        }
    }
}
