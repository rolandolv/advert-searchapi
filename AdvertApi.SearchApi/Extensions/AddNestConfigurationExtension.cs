using System;
using AdvertApi.SearchApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;

namespace AdvertApi.SearchApi.Extensions
{
    public static class AddNestConfigurationExtension
    {
        public static void AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            var elasticSearchUrl = configuration.GetSection("ES").GetValue<string>("url");

            var connectionSettings = new ConnectionSettings(new Uri(elasticSearchUrl))
                .DefaultIndex("adverts")
                .DefaultMappingFor<AdvertType>(advert => advert.IdProperty(p => p.Id));

            var client = new ElasticClient(connectionSettings);

            services.AddSingleton<IElasticClient>(client);
        }
    }
}