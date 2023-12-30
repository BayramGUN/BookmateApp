
using BookmateApp.Api;
using BookmateApp.Infrastructure.Data;
using BookmateApp.Services.Mappings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Add services to the container.

builder.Services.AddAutoMapper(typeof(MapProfile));

var connectionString = builder.Configuration.GetConnectionString("getDb");
builder.Services.AddDbContext<BookmateAppDbContext>(
    options => {
        options.UseSqlServer(connectionString);
    }
);
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(12);
});
builder.Services.AddInjections(connectionString!);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
