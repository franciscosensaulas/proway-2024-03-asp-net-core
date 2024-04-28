using ProwayWebAPI.DependencyInjections;
using SupermercadoRepositorios.DependecyInjections;
using SupermercadoServicos.DependecyInjections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .ConfigureDatabase(builder.Configuration)
    .ConfigureAutoMapper()
    .AddServices()
    .AddRepositories()
    .AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
