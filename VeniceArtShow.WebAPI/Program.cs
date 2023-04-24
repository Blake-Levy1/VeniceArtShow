
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// --->This builder.Services created from following kudvenkat, ASP NET Core Identity #66, 2:56
// https://www.youtube.com/watch?v=egITMrwMOPU
builder.Services.AddIdentity<IdentityUser, IdentityRole>();
//#66, at 5:13
builder.Services.AddIdentityFrameworkStores<BruiserAppDbContext>();

// This version was part of what we attempted =< 0421 sessions with Marty & Joshua
// I have moved them up with the other builder.Services...
// builder.Services.AddIdentityCore<UserEntity>().AddEntityFrameworkStores<ApplicationDbContext>();

//QUESTION: wasn't there an issue with the order of these builder.Services before?
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IMediaService, MediaService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Adds AuthenticationMiddleware to the I ApplicationBuilder, enabling authentication capabilities
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();