using FluentValidation.AspNetCore;
using FluentValidation.Web.FluentValidators;
using FluentValidation.Web.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddFluentValidation(conf =>
//{
//    conf.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
//    conf.AutomaticValidationEnabled = false;

//});
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews().AddFluentValidation(options =>
{
    //Way1
    //options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());

    //Way2
    options.RegisterValidatorsFromAssemblyContaining<CustomerValidator>();
});

var connectionString = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(connectionString);
});

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

app.Run();
