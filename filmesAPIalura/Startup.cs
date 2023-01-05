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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using FilmesApi.Data;
using filmesAPIalura.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using filmesAPIalura.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace filmesAPIalura
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AppDbContext>(opts => opts.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<FilmeService, FilmeService>();
            services.AddScoped<CinemaService, CinemaService>();

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(token =>
            {
                token.RequireHttpsMetadata = false;
                token.SaveToken = true;
                token.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("0asdsadasdsad06asdasdasdasd09asdasdsad0sa9")),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("IdadeMinima", policy =>
                {
                    policy.Requirements.Add(new IdadeMinimaRequirement(18));
                });
            });


            services.AddSingleton<IAuthorizationHandler, IdadeMinimaHandler>();

            services.AddCors(option => {
                option.AddPolicy("AllowSpecificOrigin", policy => policy.WithOrigins("http://localhost:4200"));
                option.AddPolicy("AllowGetMethod", policy => policy.WithMethods("POST"));
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "filmesAPIalura", Version = "v1" });
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "filmesAPIalura v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(
        options => options.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
