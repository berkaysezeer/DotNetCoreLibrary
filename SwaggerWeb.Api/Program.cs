using Microsoft.EntityFrameworkCore;
using SwaggerWeb.Api.Models;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSwaggerGen(gen =>
{
    gen.SwaggerDoc("ProductApiV1", new OpenApiInfo
    {
        Version = "1.0",
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
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
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

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/ProductApiV1/swagger.json", "Product Api");
});

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
