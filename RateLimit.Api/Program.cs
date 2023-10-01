using AspNetCoreRateLimit;
using Microsoft.AspNetCore.HttpsPolicy;

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

#region IP RATE LIMIT
//IpRateLimit deðerini json dosyasýndan alacaðýz
//builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting")); //IP rate limit için
//builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimitPolicies"));
//builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
#endregion

#region CLINET RATE LIMIT
builder.Services.Configure<ClientRateLimitOptions>(builder.Configuration.GetSection("ClientRateLimiting")); 
builder.Services.Configure<ClientRateLimitPolicies>(builder.Configuration.GetSection("ClientRateLimitPolicies"));
builder.Services.AddSingleton<IClientPolicyStore, MemoryCacheClientPolicyStore>();
#endregion

//datalarý memoryde tutmak için nesne örneði alýyoruz
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();

//rate limit için ana servis
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();

//gelen request içindeki datalarý okuyabilmek için ekliyoruz
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSingleton<IClientPolicyStore, MemoryCacheClientPolicyStore>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//builder.Services üzerindeki ayarlarý kullanmasý için
//app.UseIpRateLimiting();
app.UseClientRateLimiting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//var ipPolicyStore = app.Services.GetRequiredService<IIpPolicyStore>();
//ipPolicyStore.SeedAsync().GetAwaiter().GetResult();

var clientPolicyStore = app.Services.GetRequiredService<IClientPolicyStore>();
clientPolicyStore.SeedAsync().GetAwaiter().GetResult();

app.Run();

