﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ElderSourceVolunteerManagementCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ElderSourceVolunteerManagementCore
{
    public class Startup
    {
        IConfigurationRoot Configuration;

        public Startup (IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json").Build();
        }// end Startup constructor

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(
                Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddIdentity<AppUsers, IdentityRole>(opts => {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 12;
            })
                .AddEntityFrameworkStores<AppIdentityDbContext>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddTransient<IVolunteerRepository, EFVolunteerRepository>();
            services.AddTransient<IOpportunityRepository, EFOpportunityRepository>();
            services.AddTransient<IVolunteer2OpportunityRepository, EFVolunteer2OpportunityRepository>();
            services.AddTransient<IVolunteer2OpportunityHoursWorkedRepository, EFVolunteer2OpportunityHoursWorkedRepository>();
            services.AddTransient<IVolunteerUpdateUserRespository, EFVolunteerUpdateUserRepository>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }// end ConfigureServices method

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();
            app.UseSession();
            app.UseStaticFiles();
            app.UseIdentity();
            app.UseMvcWithDefaultRoute();
            
        }// end Configure method
    }// end Startup class
}// end ElderSourceVolunteerManagementCore namespace
