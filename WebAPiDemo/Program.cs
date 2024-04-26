using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using WebAPiDemo.Controllers;
using WebAPiDemo.Services;


var conrollerType = typeof(WeatherForecastController);
foreach (var item in conrollerType.GetCustomAttributes(false))
{
    Console.WriteLine($"{item}");
}
foreach (var item in conrollerType.GetMethods())
{
    
    Console.WriteLine(item.Name);
}






var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<SingletonService>();
builder.Services.AddScoped<ScopedService>();
//builder.Services.AddScoped<ScopedService,ScopedService>();
builder.Services.AddTransient<TransientService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();
app.Use(async (context, next) =>
{ 
    // Do work that can write to the Response.
    await next.Invoke();
    // Do logging or other work that doesn't write to the Response.
});
//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello world! Midelware");
//});

app.Run();
