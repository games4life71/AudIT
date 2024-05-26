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
builder.Services.ConfigureApplicationCookie(config =>
{
    config.Cookie.Name = "Identity.Cookie";
    config.LoginPath = "/User/Login";
    config.LogoutPath = "/User/Logout";
    config.AccessDeniedPath = "/User/Login";
    config.Cookie.SameSite = SameSiteMode.None;
    config.Cookie.SecurePolicy = CookieSecurePolicy.Always;

    config.Events.OnRedirectToAccessDenied = context =>
    {
        context.Response.StatusCode = (int)403;
        return Task.CompletedTask;
    };

    config.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = (int)401;
        return Task.CompletedTask;
    };
});
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
app.UseAuthentication();
app.UseCors(x => x.WithOrigins("https://localhost:7299","http://localhost:5283").AllowAnyMethod().AllowAnyHeader().AllowCredentials());

app.UseAuthorization();
app.Run();