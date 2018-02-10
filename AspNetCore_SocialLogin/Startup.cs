using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore_SocialLogin
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

			services.AddAuthentication(options =>
			{
				options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
				options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
				options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
			}).AddTwitter(twitterOptions =>
			{
				twitterOptions.ConsumerKey = ""; //TODO: Fill with your data from twitter
				twitterOptions.ConsumerSecret = ""; //TODO: Fill with your data from twitter
			})
			.AddFacebook(facebookOptions =>
			{
				facebookOptions.AppId = ""; //TODO: Fill with your data from facebook
				facebookOptions.AppSecret = ""; //TODO: Fill with your data from facebook
			})
			.AddCookie();
			
			services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

			app.UseAuthentication();

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
