using BookWeb.Datas;
using BookWeb.Datas.Infrastructure.Entities;
using BookWeb.WebUI.Infrastructure.Rules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWeb.WebUI.Management
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IConfigurationRoot ConfigurationRoot { get; set; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment { get; set; }   //proje içeriisndeki bilgiye root dosyasý ile eriþileceðini 

        public Startup(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            ConfigurationRoot = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true)//appsetting altýndaki dosya
                .AddEnvironmentVariables()
                .Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            if (Environment.IsDevelopment())
            {
                services.AddControllersWithViews().AddRazorRuntimeCompilation();
            }
            //config
            services.Configure<DatabaseSettings>(Configuration.GetSection("DatabaseSettings"));
            services.AddOptions();


            //cookie
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
            });
            services.AddTransient<PublishData>();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            //mvc gibi
            services.AddMvc(x =>
            {
                x.EnableEndpointRouting = false;
            });

            services.Configure<RouteOptions>(routeOptions => routeOptions.AppendTrailingSlash = true);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseStatusCodePages();
            }
            app.UseDeveloperExceptionPage();

            RedirectToHttpsWwwNonWwwRule rule = new RedirectToHttpsWwwNonWwwRule
            {
                status_code = 301,  //kendi kurallarým ruleda
                redirect_to_https = true,
                redirect_to_non_www = true,
                redirect_to_www = false,
                append_slash = true

            };
            RewriteOptions options = new RewriteOptions();
            options.Rules.Add(rule);
            app.UseRewriter(options);


            app.UseRouting();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                //ekleme olabilir
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
