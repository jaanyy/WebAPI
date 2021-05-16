using FilmsProject.API.AutoMapperProfiles;
using FilmsProject.API.Validators;
using FilmsProject.BusinessLogicLayer.Interfaces;
using FilmsProject.BusinessLogicLayer.Services;
using FilmsProject.DataAccessLayer.Context;
using FilmsProject.DataAccessLayer.Entities;
using FilmsProject.DataAccessLayer.Interfaces.Repositories;
using FilmsProject.DataAccessLayer.Interfaces.UnitOfWork;
using FilmsProject.DataAccessLayer.Repositories;
using FilmsProject.DataAccessLayer.UnitOfWork;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace FilmsProject.API
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
            services.AddDbContext<FilmsProjectDbContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("Default"));
            });

            services.AddIdentity<User, Role>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password = new PasswordOptions();
            }).AddEntityFrameworkStores<FilmsProjectDbContext>();

            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IParticipantRepository, ParticipantRepository>();
            //add repositories here

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IParticipantService, ParticipantService>();
            //add services here

            services.AddAutoMapper(typeof(AutoMapperProfile).GetTypeInfo().Assembly);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FilmsProject.API", Version = "v1" });
            });

            services.AddMvc()
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CountryDTOValidator>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FilmsProject.API v1"));
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
