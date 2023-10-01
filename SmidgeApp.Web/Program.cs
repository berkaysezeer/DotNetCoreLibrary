using Smidge;
using Smidge.Cache;
using Smidge.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSmidge(builder.Configuration.GetSection("Smidge"));

var app = builder.Build();

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

app.UseSmidge(bundle =>
{
    //debug true olan bundlelar için cache dosyasý baþtan oluþur(program her ayaða kadldýrýldðýnda)
    //debug modda da bundle oluþur
    //bundle.CreateJs("JsBundle", "~/js/")  //tek tek dosya belirtmek yerine klasöer belirtebiliriz
    //.WithEnvironmentOptions(BundleEnvironmentOptions
    //.Create()
    //.ForDebug(builder => builder.EnableCompositeProcessing()
    //.EnableFileWatcher()
    //.SetCacheBusterType<AppDomainLifetimeCacheBuster>()
    //.CacheControlOptions(enableEtag: false, cacheControlMaxAge: 0))
    //.Build());

    bundle.CreateJs("JsBundle", "~/js/");  //tek tek dosya belirtmek yerine klasöer belirtebiliriz


    //bundle.CreateJs("JsBundle","~/js/site.js", "~/js/site2.js");

    bundle.CreateCss("CssBundle", "~/css/site.css", "~/lib/bootstrap/dist/css/bootstrap.css");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
