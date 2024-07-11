using FamChron.JwtService.Data;
using FamChron.JwtService.JwtHandler;
using FamChron.JwtService.JwtHandler.Contracts;
using FamChron.JwtService.Repositories;
using FamChron.JwtService.Repositories.Contracts;
using FamChron.JwtService.Services;
using FamChron.JwtService.Services.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddTransient<IDbConnection>((cs) => new NpgsqlConnection(builder.Configuration.GetConnectionString("AuthDbConnection")));
builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));

//DI
builder.Services.AddSingleton<AuthDbContext>();
builder.Services.AddScoped<IJwtHandler, JwtHandler>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddGrpc();

builder.Services.AddAuthentication(a =>
    {
        a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(a =>
    {
        a.RequireHttpsMetadata = false;
        a.SaveToken = true;
        a.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                                                        builder.Configuration.GetSection("Jwt:Token").Value!))
        };
    });


//builder.WebHost.ConfigureKestrel((context, serverOptions) =>
//{
//    var kestrelSection = context.Configuration.GetSection("Kestrel");

//    serverOptions.Configure(kestrelSection)
//        .Endpoint("HTTPS", listenOptions =>
//        {
//            listenOptions.;
//        });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGrpcService<AuthenticationService>();

//app.MapControllers();

app.Run();
