/**********************************************************************
* FileName :      Startup
* Tables :        none
* Author :        º«³¬(Simple)
* CreateTime :    2021/3/9 11:31:47
* Description :   
* 
* Revision History
* Author           ModifyTime          Description
* 
**********************************************************************/

using IdentityServer4.AccessTokenValidation;
using smp.services.invoice.core;
using smp.services.invoice.core.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;
using Consul;

namespace smp.services.invoice.portal
{
    /// <summary>
    /// program default config
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// DI
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(new ParamsValidateFilter());
            });

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme).AddIdentityServerAuthentication(x =>
            {
                x.Authority = Configuration["Identity:Authority"];
                x.RequireHttpsMetadata = Configuration["Identity:RequireHttpsMetadata"] == "true";
                x.ApiName = Configuration["Identity:ApiName"];
            });

            services.AddDbContext<InvoiceDbContext>(option =>
            {
                option.UseLazyLoadingProxies();
                option.UseMySQL(Configuration["Mysql:ConnectionString"], x => x.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly(), Assembly.GetAssembly(typeof(InvoiceDbContext)));

            services.AddInvoiceCore();

            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Invoice",
                    Version = "V1",
                    Description = "¿ªÆ±ÏµÍ³"
                });

                var xmlFilePath = Environment.CurrentDirectory + "/" + Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                option.IncludeXmlComments(xmlFilePath);
            });
        }

        /// <summary>
        /// service register.
        /// </summary>
        /// <param name="hostApplicationLifetime"></param>
        public static void RegisterConsul(IHostApplicationLifetime hostApplicationLifetime)
        {
            var consulClient = new ConsulClient(x => x.Address = new Uri("http://consul-ui.hwkj-system-dev.svc.cluster.local:8500/"));
            var httpCheck = new AgentServiceCheck
            {
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
                Interval = TimeSpan.FromSeconds(10),
                HTTP = "http://192.168.1.80/Health",
                Timeout = TimeSpan.FromSeconds(5)
            };

            var registeration = new AgentServiceRegistration
            {
                Checks = new[] { httpCheck },
                ID = Guid.NewGuid().ToString(),
                Name = "Invoice",
                Address = "192.168.1.80",
                Port = 8081,
                Tags = new string[] { "primary", "v1" },
                EnableTagOverride = false
            };

            consulClient.Agent.ServiceRegister(registeration).Wait();
            hostApplicationLifetime.ApplicationStopped.Register(() => consulClient.Agent.ServiceDeregister(registeration.ID).Wait());
        }

        /// <summary>
        /// middleware
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="hostApplicationLifetime"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IHostApplicationLifetime hostApplicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "Invoice");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action}");
            });

            RegisterConsul(hostApplicationLifetime);
        }
    }
}
