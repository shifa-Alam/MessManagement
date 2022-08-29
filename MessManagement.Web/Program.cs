using MessManagement.Web.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MM.bll.Services;
using MM.Core.Infra.Repos;
using MM.Core.Services;
using MM.Repo;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextPool<MMDBContext>(options =>
 options.UseLazyLoadingProxies()
 .UseSqlServer(connectionString));


//builder.Services.AddDbContext<MMDBContext>(x => x.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IMemberRepo, MemberRepo>();

builder.Services.AddScoped<IMealService, MealService>();
builder.Services.AddScoped<IMealRepo, MealRepo>();


//builder.Services.AddMvc()
//                .AddApplicationPart(typeof(WeatherForecastController).Assembly)
//                .AddControllersAsServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;


app.Run();
