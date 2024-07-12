using FamChron.Gateway.Protos;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGrpcClient<AuthenticationGrpcService.AuthenticationGrpcServiceClient>(o =>
{
    o.Address = new Uri("https://localhost:5059");
});

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
                     .AddJsonFile("configOcelot.json", optional: false, reloadOnChange: true)
                     .AddEnvironmentVariables();
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerForOcelotUI(option =>
    {
        option.PathToSwaggerGenerator = "/swagger/docs";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.UseOcelot();

await app.RunAsync();


