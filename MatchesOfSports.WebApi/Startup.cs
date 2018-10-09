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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MatchesOfSports.BusinessLogic.Services;
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
            services.AddMvc();
        
            services.AddDbContext<DbContext, MatchesOfSportsContext>(o => o.UseSqlServer(Configuration.GetConnectionString("MatchesOfSportsDB")));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRepositoryOf<User>, UserRepository>();
            services.AddScoped<IUsersService, UserService>();
            services.AddScoped<IRepositoryOf<Team>, TeamRepository>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IRepositoryOf<Sport>, SportRepository>();
            services.AddScoped<ISportService, SportService>();
            services.AddScoped<IRepositoryOf<Match>, MatchRepository>();
            services.AddScoped<IMatcheService, MatchService>();
            services.AddScoped<IRepositoryOf<Comment>, CommentRepository>(); 
            services.AddScoped<ICommentService, CommentService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
