using AudIT.Applicationa;
using AudIT.Applicationa.MapperProfiles;
using AudIT.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationServices();
builder.Services.AddAutoMapper(typeof(MyCustomProfile).Assembly);

builder.Services.AddSwaggerGen(c => c.SwaggerDoc(
    "v1",
    new OpenApiInfo
    {
        Version = "v1",
        Title = "AudIT API",
    }
));

// builder.Logging.AddConsole();
// builder.Logging.AddDebug();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {});
}

app.UseRouting();

// app.UseCors(x => x
//     .AllowAnyOrigin()
//     .AllowAnyMethod()
//     .AllowAnyHeader());
//
// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapControllers();
// });
app.MapControllers();
app.Run();