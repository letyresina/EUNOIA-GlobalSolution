using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EUNOIA.Configuration
{
    /// <summary>
    /// Classe responsável por configurar o Swagger para suportar múltiplas versões da API.
    /// </summary>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="ConfigureSwaggerOptions"/>.
        /// </summary>
        /// <param name="provider">Provedor de descrições de versão da API.</param>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// Configura o Swagger para gerar documentação para cada versão da API.
        /// </summary>
        /// <param name="options">Opções de configuração do Swagger.</param>
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, new OpenApiInfo
                {
                    Title = $"EUNOIA API {description.ApiVersion}",
                    Version = description.ApiVersion.ToString()
                });
            }
        }
    }
}