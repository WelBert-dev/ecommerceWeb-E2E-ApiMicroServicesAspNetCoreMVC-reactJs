using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexão com banco 
var mySqlConnectionString = builder.Configurations.getConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => 
                options.UseMySql(mySqlConnectionString, ServerVersion.AutoDetect(mySqlConnectionString)));

// Injeta o AutoMapper e mapeia as entidades no contexto atual de execução (Injeção DTO's)
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
