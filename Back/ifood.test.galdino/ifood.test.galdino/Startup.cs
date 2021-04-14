using ifood.test.galdino.domain.Infraestructure;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Polly;
using System;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using ifood.test.galdino.api.Configurations.AutoMapper;
using ifood.test.galdino.api.Configurations.CorsConfig;
using ifood.test.galdino.api.Configurations.DependencyInjection;
using ifood.test.galdino.service;
using ifood.test.galdino.service.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ifood.test.galdino
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
           

            ConfigureOptions(services);

            services.AddOptions();
            AutoMapperConfiguration.Register(services, Configuration);

            services.AddServices();
            services.AddRepositories();
            services.AddDatabase(Configuration);
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ifood.test.galdino", Version = "v1" });
            });

            #region .:: Configuration polly
            var timeout = TimeSpan.FromSeconds(50);
            var retry = TimeSpan.FromMilliseconds(600000);
            #endregion

            #region .:: Polly HttpClient injection
            services.AddHttpClient<IWebRequestService, WebRequestService>()
                .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(2, _ => retry))
                .AddPolicyHandler(request => Policy.TimeoutAsync<HttpResponseMessage>(timeout))
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler { ServerCertificateCustomValidationCallback = AcceptAllCertifications });
            #endregion

        }

        private static bool AcceptAllCertifications(object sender, X509Certificate certification, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true;

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ifood.test.galdino v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseAuthorization();
            app.UseCorsConfig();
            app.UseEndpointsConfig();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureOptions(IServiceCollection services)
        {
            var infraConfig = new Infraestructure();
            new ConfigureFromConfigurationOptions<Infraestructure>(
                    Configuration.GetSection("Infrastructure"))
                .Configure(infraConfig);
            services.AddSingleton(infraConfig);
        }
    }
}
