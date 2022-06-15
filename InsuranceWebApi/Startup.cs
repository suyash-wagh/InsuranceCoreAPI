using InsuranceLib.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using InsuranceLib.DAL.Models;
using InsuranceLib.BL.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using InsuranceLib.DAL.Repositories.Users;
using InsuranceLib.DAL.Repositories;

namespace InsuranceWebApi
{
    public class Startup
    {
        public string ConnectionString { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DefaultConnection");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JWT:Secret"])),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,

                ValidIssuer = Configuration["JWT:Issuer"],
                ValidAudience = Configuration["JWT:Audience"],
                ClockSkew = TimeSpan.Zero
            };

            services.AddControllers();
            
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCors", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            services.AddDbContext<InsuranceDbContext>(options => options.UseSqlServer(ConnectionString));
            
            services.AddScoped<UsersService>();
            
            services.AddTransient<IUsersRepository<User>, UsersRepository>();

            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            //services.AddScoped<IRepository<State>, RepositoryBase<State>>();

            services.AddIdentity<User, IdentityRole>()
             .AddEntityFrameworkStores<InsuranceDbContext>()
             .AddDefaultTokenProviders();
            
            services.AddSwaggerGen();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer("Bearer", options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = tokenValidationParameters;

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();

            app.UseCors("EnableCors");

            app.UseSwaggerUI();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
