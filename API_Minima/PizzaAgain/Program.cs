using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore; // ADICIÒN DE ENTITY FRAMEWORK
using PizzaAgain.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<PizzaData>(options => options.UseInMemoryDatabase("items")); /// LLAMADO AL DATABASE

builder.Services.AddSwaggerGen( x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PizzaTorium API",
        Description = "The Pandemoniums Pizza",
        Version = "v1"});
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(x =>
{
    x.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaTorium API V1");
});

app.MapGet("/", () => "Hello World!");

app.MapGet("/pizzas", async (PizzaData db) => await db.Pizzas.ToListAsync()); // MAPPEO API PARA ENRUTAR EL RESULTADO DE LA BASE DE DATOS

app.Run();
