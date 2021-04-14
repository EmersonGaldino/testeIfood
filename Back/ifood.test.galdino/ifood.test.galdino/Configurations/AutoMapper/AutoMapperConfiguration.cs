using ifood.test.galdino.api.Models.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using AutoMapper;

namespace ifood.test.galdino.api.Configurations.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<CustomMappingProfile>();
                mc.AddProfile<DomainToModelViewProfile>();
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
     
    }
}
