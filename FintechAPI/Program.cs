using FintechApi.Repositoy;
using FintechApi.Repositoy.Interfaces;
using FintechAPI.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Conex�o com o Banco de Dados
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DataBaseContext>(options =>
{
    options.UseOracle(connectionString).EnableSensitiveDataLogging(true);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

});

// Inje��o de depend�ncia
builder.Services.AddScoped(typeof(IBaseRepository), typeof(BaseRepository));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddMvc(); //add for swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MY API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
