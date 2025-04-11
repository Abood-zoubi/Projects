using Biding_management_System.Application.Services;
using Biding_management_System.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Biding_management_System.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;
using Biding_management_System.Application.Interfaces;
using Biding_management_System.Infrastructure.Interfaces;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register services
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<ITenderRepository, TenderRepository>();
builder.Services.AddScoped<ITenderService, TenderService>();
builder.Services.AddScoped<IBidService, BidService>();
builder.Services.AddScoped<IBidRepository, BidRepository>();
builder.Services.AddScoped<IBidEvaluationRepository, BidEvaluationRepository>();
builder.Services.AddScoped<BidEvaluationService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<SmtpClient>(sp => new SmtpClient("smtp.SkySoftware.com")
{
    Credentials = new System.Net.NetworkCredential("AZ1234", "AZ1234"),
    EnableSsl = true
});

// Register Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Tender Management API", Version = "v1" });
});

// Add authentication
var key = Encoding.ASCII.GetBytes("AZ1234");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tender Management API v1");
});

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
