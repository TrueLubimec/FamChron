using FamChron.Api.Repositories;
using FamChron.Api.Repositories.Contracts;
using FamChron.Api.Data;
using FamChron.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<FamChronDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FamChronConnection")));

builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IStoryRepository, StoryRepository>();
builder.Services.AddScoped<IStorysEventsRepository, StorysEventsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
            policy.WithOrigins("https://localhost:7168", "https://localhost:7047")
            .AllowAnyMethod()
            .WithHeaders(HeaderNames.ContentType)
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();