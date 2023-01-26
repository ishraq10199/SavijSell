using Ishraq.SavijSellApi.Models;
using Ishraq.SavijSellApi.Repositories;
using Ishraq.SavijSellApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var dbSettingsSection = builder.Configuration.GetSection("DatabaseSettings");
var cryptoSettingsSection = builder.Configuration.GetSection("CryptoSettings");

builder.Services.Configure<DatabaseSettings>(dbSettingsSection);
builder.Services.Configure<CryptoSettings>(cryptoSettingsSection);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "localhost:5176",
				ValidAudience = "localhost:5176",
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(cryptoSettingsSection["JwtSigningKey"]))
			};
        });


builder.Services.AddSingleton<IUsersRepository, UsersRepository>();
builder.Services.AddSingleton<IUsersService, UsersService>();
builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
builder.Services.AddSingleton<IProductsRepository, ProductsRepository>();
builder.Services.AddSingleton<IProductsService, ProductsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
