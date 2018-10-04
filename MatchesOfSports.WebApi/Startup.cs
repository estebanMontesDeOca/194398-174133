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
        
            services.AddDbContext<DbContext, HomeworksContext>(o => o.UseSqlServer(Configuration.GetConnectionString("MatchesOfSportsDB")));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRepositoryOf<User>, UserRepository>();
            //services.AddScoped<, HomeworkLogic>();
            services.AddScoped<IRepositoryOf<Team>, TeamRepository>();
            //services.AddScoped<IExerciseLogic, ExerciseLogic>();
            services.AddScoped<IRepositoryOf<Sport>, SportRepository>();
            //services.AddScoped<ISessionLogic, SessionLogic>();
            services.AddScoped<IRepositoryOf<Match>, MatchRepository>();
            services.AddScoped<IRepositoryOf<Comment>, CommentRepository>(); 
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
