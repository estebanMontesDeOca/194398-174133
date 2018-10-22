using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MatchesOfSports.BusinessLogic.Services;
using MatchesOfSports.DataAccess;
using MatchesOfSports.Domain;
using Swashbuckle.AspNetCore.Swagger;
using MatchesOfSports.DataAccess.Interface;

namespace MatchesOfSports.WebApi
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
            
            /*services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "MatchesOfSportsAPI", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "header", Description = "User token", Name = "Authorization", Type = "apiKey" });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                { "Bearer", Enumerable.Empty<string>() },
                });
                            });*/
            services.AddDbContext<MatchesOfSportsContext>(o => o.UseSqlServer(Configuration.GetConnectionString("MatchesOfSportsDB")));
            services.AddScoped<UnitOfWork>();

            services.AddScoped<IUsersService, UserService>();
            //services.AddScoped<IRepositoryOf<User>, UserRepository>();
            services.AddScoped<IUsersService, UserService>();
            //services.AddScoped<IRepositoryOf<Team>, TeamRepository>();
            services.AddScoped<TeamService>();
            //services.AddScoped<IRepositoryOf<Sport>, SportRepository>();
            services.AddScoped<ISportService, SportService>();
            //services.AddScoped<IRepositoryOf<Match>, MatchRepository>();
            services.AddScoped<IMatchService, MatchService>();
            //services.AddScoped<IRepositoryOf<Comment>, CommentRepository>(); 
            services.AddScoped<ICommentService, CommentService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           /*  if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();*/
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            /*app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MatchesOfSportsAPI V1");
            });*/
           // app.UseHttpsRedirection();
            app.UseMvc();
    /*        app.UseMvc(routes => {
                routes.MapRoute(
                    name: "Default",
                    template: "api/{controller}/{id?}"
                );
});*/
        }
    }
}
