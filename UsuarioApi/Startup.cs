using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using UsuarioApi.Data;
using UsuarioApi.Services;

namespace UsuarioApi
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
            //injeção
            services.AddDbContext<UserDbContext>(opts => opts.UseNpgsql(Configuration.GetConnectionString("UsuarioConnection"), opts =>
             opts.SetPostgresVersion(new Version("9.4"))));
            //injeção
            services.AddIdentity<IdentityUser<int>, IdentityRole<int>>(
                opt => opt.SignIn.RequireConfirmedAccount = true
                )
                .AddEntityFrameworkStores<UserDbContext>()
                .AddDefaultTokenProviders();
            //injeção
            services.AddScoped<EmailService, EmailService>();
            services.AddScoped<CadastroService, CadastroService>();
            //injeção
            services.AddScoped<LogoutService, LogoutService>();
            //injeção
            services.AddScoped<LoginService, LoginService>();
            //injeção
            services.AddScoped<TokenService,TokenService>();    
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); 
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
