﻿using He.BSF.Infrastructure.Data;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace He.BSF.Api.Extensions
{
    public static class ServiceCollectionCosmosDbExtensions
    {
        public static IServiceCollection AddCosmosDb(this IServiceCollection services, Uri serviceEndpoint,
            string authKey, string databaseName, List<string> collectionNames)
        {
            var documentClient = new DocumentClient(serviceEndpoint, authKey, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            documentClient.OpenAsync().Wait();

            var cosmosDbClientFactory = new CosmosDbClientFactory(databaseName, collectionNames, documentClient);

            cosmosDbClientFactory.EnsureDbSetupAsync().Wait();

            services.AddSingleton<ICosmosDbClientFactory>(cosmosDbClientFactory);

            return services;
        }
    }
}
