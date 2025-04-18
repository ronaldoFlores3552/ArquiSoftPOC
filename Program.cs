using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

//ALMACENAMIENTO EN MEMORIA
var usuarios = new List<Usuario>();
var proveedores = new List<Proveedor>();
var productos = new List<Producto>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

//CONFIGURACION DE LAS APIS.
app.MapPost("/usuarios", async (HttpContext context) => {
    var usuario = await JsonSerializer.DeserializeAsync<Usuario>(context.Request.Body);
    if (usuario == null) return Results.BadRequest("Datos inválidos.");
    usuario.Id=usuarios.Count()+1;

    usuarios.Add(usuario);

    return Results.Ok(new { status="UsuarioCreado",user_id=usuario.UserId});
});

app.MapGet("/usuarios/{userId}", (string userId) => { 
    var usuario= usuarios.FirstOrDefault(u=>u.UserId==userId);
    return usuario is not null? Results.Ok(usuario): Results.NotFound(new { detail="Usuario no encontrado"});
});

//proveedores
app.MapPost("/proveedores", async (HttpContext context) =>
{
    var proveedor= await JsonSerializer.DeserializeAsync<Proveedor>(context.Request.Body);

    if (proveedor == null) return Results.BadRequest("Datos inválidos.");

    proveedor.Id=proveedor.Id+1;

    return Results.Ok(new {status="ProveedorCreado", proveedor_id=proveedor.Id});
});

app.MapGet("/proveedores/{proveedorId}", (string proveedorId) => {
    var proveedor = proveedores.FirstOrDefault(p => p.SupplierId == proveedorId);
    return proveedor is not null ? Results.Ok(proveedor) : Results.NotFound(new { detail = "Proveedor no encontrado"});
});

app.MapPost("/productos", async (HttpContext context) => {
    var producto = await JsonSerializer.DeserializeAsync<Producto>(context.Request.Body);
    if (producto == null) return Results.BadRequest("Datos inválidos.");
    producto.Id=productos.Count()+1;
    productos.Add(producto);

    return Results.Ok(new {status="Producto agregado",product_id=producto.Id});
});

app.MapGet("/productos/{productId}", (string productId) =>
{
    var producto = productos.FirstOrDefault(p => p.ProductId == productId);
    return producto is not null ? Results.Ok(producto) : Results.NotFound(new { detail = "Producto no encontrado" });
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
