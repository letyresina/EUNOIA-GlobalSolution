using EUNOIA.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Conexão com o SQL Server
builder.Services.AddDbContext<EunoiaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EunoiaConnection")));

// Add Controllers
builder.Services.AddControllers();

// Swagger (documentação)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
