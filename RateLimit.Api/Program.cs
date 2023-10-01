using AspNetCoreRateLimit;

//https://dotnethow.net/implementing-api-rate-limiting-in-net-web-apis/

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//appsettings.json ayarlarý için tanýmlýyoruz
builder.Services.AddOptions();

//requestler (kaç istek, kaç istek kaldý vs) cache'te tutuluyor
builder.Services.AddMemoryCache();

//IpRateLimit deðerini json dosyasýndan alacaðýz
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimitPolicies"));

builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();

//datalarý memoryde tutmak için nesne örneði alýyoruz
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();

//rate limit için ana servis
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();

//gelen request içindeki datalarý okuyabilmek için ekliyoruz
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//builder.Services üzerindeki ayarlarý kullanmasý için
app.UseIpRateLimiting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
