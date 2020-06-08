using System.IO;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;

namespace He.BSF.Api.Extensions
{
    public static class ServiceCollectionCustomSwaggerExtensions
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                }

                options.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "He.BSF.Api.xml"));
                options.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "He.BSF.Core.xml"));
            });

            return services;
        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = $"To-do REST API  {description.ApiVersion}",
                Version = description.ApiVersion.ToString(),
                Description = "To-do example for partitioned repository ASP.NET Core Web API with Azure CosmosDB Backend"
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}
