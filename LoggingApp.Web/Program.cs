var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//built-in logging providerslarý kapatýyoruz
//builder.Logging.ClearProviders();

var app = builder.Build();
var logger = app.Services.GetRequiredService<ILogger<Program>>();
string message = "Uygulama ayaða baþlatýlýyor...";

//core, 3 provider saðlýyor; console, debug, EventSource, EventLog
logger.LogTrace(message);
logger.LogDebug(message);
logger.LogInformation(message);
logger.LogWarning(message);
logger.LogError(message);
logger.LogCritical(message);


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
