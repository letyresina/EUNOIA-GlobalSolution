using EUNOIA.Data;
using EUNOIA.Repositories;
using EUNOIA.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer; 

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte ao versionamento de API
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});

// Adiciona suporte ao versionamento no Swagger
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV"; 
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<EUNOIA.Configuration.ConfigureSwaggerOptions>();


// Conexão com o SQL Server
builder.Services.AddDbContext<EunoiaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EunoiaConnection")));

// Injeção de dependência para Company
builder.Services.AddScoped<CompanyRepository>();
builder.Services.AddScoped<CompanyService>();

// Injeção de dependência para User
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserRepository>();

// Injeção de dependência para PrivacySetting
builder.Services.AddScoped<PrivacySettingRepository>();
builder.Services.AddScoped<PrivacySettingService>();


// Controllers + Configuração para enums como texto
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Swagger (documentação)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

    app.UseSwaggerUI(options =>
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"EUNOIA API {description.GroupName.ToUpperInvariant()}");
        }
    });
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();