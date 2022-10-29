using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace StoreAPIRestful
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "API Store",
                Version = description.ApiVersion.ToString(),
                Description = "Practica de API que consume la fakestoreapi.com.",
                Contact = new OpenApiContact()
                {
                    Email = "axelromero@alu.frp.utn.edu.ar",
                    Name = "Axel Romero",
                }
            };

            if (description.IsDeprecated)
            {
                info.Version += "This API version has been deprecated";
            }

            return info;
        }

        public void Configure(SwaggerGenOptions options)
        {
            // Add Swagger Documentation for each API Version we have
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }

        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }
    }
}
