using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Middleware_Services.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyCustomMiddleware
    {
        public MyCustomMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            this.loggerFactory = loggerFactory.CreateLogger<MyCustomMiddleware>();
            this.loggerFactory.LogInformation("Middleware is started");
        }

        private readonly RequestDelegate _next;
        private readonly ILogger loggerFactory;

        public async Task Invoke(HttpContext httpContext)
        {
            this.loggerFactory.LogInformation("My middleware is executed");
            await _next.Invoke(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
