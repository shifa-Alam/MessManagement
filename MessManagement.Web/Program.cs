
using Microsoft.EntityFrameworkCore;
using MM.bll.Services;
using MM.Core.Infra.Repos;
using MM.Core.Services;
using MM.Repo;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MMDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IMemberRepo, MemberRepo>();

builder.Services.AddScoped<IMealService, MealService>();
builder.Services.AddScoped<IMealRepo, MealRepo>();
builder.Services.AddScoped<IBazarService, BazarService>();
builder.Services.AddScoped<IBazarRepo, BazarRepo>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//builder.Services.AddMvc()
//                .AddApplicationPart(typeof(WeatherForecastController).Assembly)
//                .AddControllersAsServices();

builder.Services.AddCors();

var app = builder.Build();
// global cors policy
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials

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
