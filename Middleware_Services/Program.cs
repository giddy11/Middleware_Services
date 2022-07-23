using Middleware_Services.Services;
using Middleware_Services.TypesOfServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<MessagingSenderService, TextMessageService>();
builder.Services.AddSingleton<ParentSingleton, Singleton>();
builder.Services.AddScoped<ParentScoped, Scoped>();
builder.Services.AddTransient<ParentTransient, Transient>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Hello from MW1");
//    await next();
//    await context.Response.WriteAsync("\nGoodbye from MW1");
//});


//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("\nHello from MW2");
//    await next();
//    await context.Response.WriteAsync("\nGoodbye from MW2");
//});


//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("\nHello from MW3");
//});

app.Run();
