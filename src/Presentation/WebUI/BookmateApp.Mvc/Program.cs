using BookmateApp.Infrastructure;
using BookmateApp.Infrastructure.Data;
using BookmateApp.Mvc.Extensions;
using BookmateApp.Services.Mappings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
// Add services to the container.

builder.Services.AddAutoMapper(typeof(MapProfile));

var connectionString = builder.Configuration.GetConnectionString("getDb");
/* builder.Services.AddDbContext<BookmateAppDbContext>(
    options => {
        options.UseSqlServer(connectionString);
    }
); */
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(12);
});
builder.Services.AddInjections(connectionString);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = "/Users/Login";
                    option.AccessDeniedPath = "/Users/AccesDenied";
                    option.ReturnUrlParameter = "/pageToGo";

                });

builder.Services.AddMemoryCache();
builder.Services.AddResponseCaching(opt =>
{
    opt.SizeLimit = 100000;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<BookmateAppDbContext>();
context.Database.EnsureCreated();
DbSeedOperations.SeedDatabase(context);

app.UseHttpsRedirection();
app.UseResponseCaching();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
