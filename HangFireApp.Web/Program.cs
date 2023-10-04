using Hangfire;
using HangFireApp.Web.Models;
using HangFireApp.Web.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//sql server kullanacaðý yolu belirteceðiz
var connectionString = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddHangfire(x => x.UseSqlServerStorage(connectionString));

//projenin ayný zamanda bir hangfire server olmasýný saðlýyoruz
builder.Services.AddHangfireServer();

//IEmailSender olan yerde EmailSender'dan neste örneði alýr
builder.Services.AddScoped<IEmailSender, EmailSender>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//dashboard aktif olmasý için ekliyoruz
app.UseHangfireDashboard();

app.Run();
