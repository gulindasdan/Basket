using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using ProductService.API.Middleware;
using ProductService.Application;
using ProductService.Infrastructure;
using ProductService.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status404NotFound));
    opt.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
    opt.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product.API", Version = "v1" });
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "ProductService.API.xml"));
});

builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseMiddleware<ExceptionHandlingMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var initializer = scope.ServiceProvider.GetRequiredService<ProductDbContextInitializer>();
    await initializer.Initialize();
}

app.Run();
