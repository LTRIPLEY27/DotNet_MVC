using Microsoft.OpenApi.Models;  // ADICI�N DE SWAGGER


var builder = WebApplication.CreateBuilder(args); // GENERADOR QUE CREA LA INSTANCIA DE LA APP

/// <summary>
///  BLOQUE DE INCORPORACI�N DE SWAGGER
/// </summary>
/// 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzaStore API", Description = "Making the pizzas and pepperonnis", Version = "v1" }));

var app = builder.Build();// LA INSTANCIA APP SE USAR� PARA CONFIGURAR EL ENRUTAMIENTO

if (app.Environment.IsDevelopment()) //COMPROBACI�N DE LA APP
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
});

/// <summary>
/// /FINAL DEL BLOQUE SWAGGER
/// </summary>
app.MapGet("/", () => "Hello World!");

app.Run();
