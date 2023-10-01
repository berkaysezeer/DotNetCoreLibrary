using AspNetCoreRateLimit;

//https://dotnethow.net/implementing-api-rate-limiting-in-net-web-apis/

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//appsettings.json ayarlar� i�in tan�ml�yoruz
builder.Services.AddOptions();

//requestler (ka� istek, ka� istek kald� vs) cache'te tutuluyor
builder.Services.AddMemoryCache();

//IpRateLimit de�erini json dosyas�ndan alaca��z
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimitPolicies"));

builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();

//datalar� memoryde tutmak i�in nesne �rne�i al�yoruz
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();

//rate limit i�in ana servis
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();

//gelen request i�indeki datalar� okuyabilmek i�in ekliyoruz
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//builder.Services �zerindeki ayarlar� kullanmas� i�in
app.UseIpRateLimiting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
