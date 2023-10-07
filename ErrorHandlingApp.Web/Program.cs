using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //herhangi bir hata al�nd���nda hata sayfas�na y�nelndirilmesi sa�lan�r
    //app.UseExceptionHandler("/Home/Error");

    //custom hata sayfas� da yazabiliriz

    app.UseExceptionHandler(context =>

    context.Run(async page =>
    {
        page.Response.ContentType = "text/html";
        await page.Response.WriteAsync($"<html><head><h1>{page.Response.StatusCode}</h1></head></html>");
    })
    );

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    //veri taban� hatalar�n� yakalamak i�in
    app.UseDatabaseErrorPage();

    //stack, query, cookies, headers gibi tablar i�erek sayfa a��l�r
    app.UseDeveloperExceptionPage();

    //status code d�nmesi i�in ayar yap�yoruz
    //app.UseStatusCodePages("text/plain", "Beklenmedik bir hata ile kar��la��ld�: {0}");

    app.UseStatusCodePages(async statusCodeContext =>
    {
        //statusCodeContext.HttpContext.Response.ContentType = Text.Plain;
        statusCodeContext.HttpContext.Response.ContentType = Text.Plain;

        await statusCodeContext.HttpContext.Response.WriteAsync(
            $"Beklenmedik bir hata ile kar��la��ld�: {statusCodeContext.HttpContext.Response.StatusCode}");
    });
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
