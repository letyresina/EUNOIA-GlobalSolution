using EUNOIA.Data;
using EUNOIA.Repositories;
using EUNOIA.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

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
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();