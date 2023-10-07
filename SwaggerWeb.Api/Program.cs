using Microsoft.EntityFrameworkCore;
using SwaggerWeb.Api.Models;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSwaggerGen(gen =>
{
    gen.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Product Api",
        Description = "Ürün ekleme, silme, güncelleme iþlemlerini gerçekleþtiren api",
        Contact = new OpenApiContact
        {
            Name = "Berkay SEZER",
            Email = "info@berkaysezer.com",
            Url = new Uri("https://berkaysezer.com"),
        }
    });

    //xml dosyasýnýn ayarlarýný yapýyoruz
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName()}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    gen.IncludeXmlComments(xmlPath);
});



builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContext<SwaggerDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
