using IdentityServer4;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography.X509Certificates;

namespace Tng.IdentityServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // configure identity server with in-memory stores, keys, clients and scopes
            var idServerBuilder = services.AddIdentityServer()
                //.AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients())
                .AddTestUsers(Config.GetUsers());

            //Assign singing certificate
            var certStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            certStore.Open(OpenFlags.ReadOnly);
            var certCollection = certStore.Certificates.Find(X509FindType.FindByThumbprint, "c0735ff8f0fa92fa53f5581a2f93e5d3a36f5cce", false);
            if (certCollection.Count == 0) idServerBuilder.AddDeveloperSigningCredential();
            else idServerBuilder.AddSigningCredential(certCollection[0]);



            services.AddAuthentication()
                .AddGoogle("Google", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                    options.ClientId = "204600520909-9bq621dn0qk9p9udresupebm1395cio3.apps.googleusercontent.com";
                    options.ClientSecret = "Smc5Med-DbBMEnmV4W5Mcx2X";
                });
            //.AddOpenIdConnect("oidc", "OpenID Connect", options =>
            //{
            //    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
            //    options.SignOutScheme = IdentityServerConstants.SignoutScheme;

            //    options.Authority = "https://accounts.google.com";
            //    options.ClientId = "114269938808-gvhr06t47qgg5rm4bonu2gj86mvkrk4r.apps.googleusercontent.com";
            //    options.ClientSecret = "7xFNk8ZWaqReK3j36LPhXNFr";

            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        NameClaimType = "name",
            //        RoleClaimType = "role"
            //    };
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
