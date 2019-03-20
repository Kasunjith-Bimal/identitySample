using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MVC
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

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
                //options.DefaultAuthenticateScheme = "Cookies";
            }).AddCookie("Cookies")
             .AddOpenIdConnect("oidc", options =>
             {

                 options.SignInScheme = "Cookies";
                 options.RequireHttpsMetadata = false;
                 options.Authority = "http://localhost:61632";
                 options.ClientId = "mvc";
                 options.ResponseType = "id_token";
                 //options.CallbackPath = new PathString("...")
                 //options.SignedOutCallbackPath = new PathString("...")
                 options.Scope.Add("openid");
                 options.Scope.Add("email");
                 options.Scope.Add("office");
                 options.Scope.Add("profile");


             });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
