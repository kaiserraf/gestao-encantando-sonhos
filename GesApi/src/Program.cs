using System.Text;
using gesApi.src.Config;
using gesApi.src.Data.DataInterfaces;
using gesApi.src.Services;
using gesApi.src.Services.ServicesInterface;
using gesApi.src.Utils;
using gesApi.src.Utils.UtilsInterfaces;
using GesApi.src.Utils;
using GesApi.src.Utils.UtilsInterfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GesContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// data
builder.Services.AddScoped<IUserAuthData, UserAuthData>();

// service
builder.Services.AddScoped<IUserAuthService, UserAuthService>();

// utils
builder.Services.AddScoped<IAuthenticateUser, AuthenticateUser>();
builder.Services.AddScoped<ICryptData, CryptData>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
        )
    };
});

builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();