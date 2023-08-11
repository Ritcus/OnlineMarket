using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineMarket.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Configure dependency injection container with a DbContext for Entity Framework Core to enable database access in the application
builder.Services.AddDbContext<OnlineMarketDbContext>(x =>
        x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Adding Microsoft Identity to the services
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<OnlineMarketDbContext>()
    .AddDefaultTokenProviders();

//Adding Jwt Bearer token to the services 
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Iaminlovewithverymuchbadkeyisverygoodandbeketseperated"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "api.com", //the api or the application server URL
            ValidAudience = "Marketplace",
            IssuerSigningKey = key
        };
    });

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
