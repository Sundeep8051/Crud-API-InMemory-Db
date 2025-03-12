using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStoreApi.Middlewares
{
    public class RequestInterceptMiddleware(ILogger<RequestInterceptMiddleware> logger, RequestDelegate next)
    {
        private readonly ILogger<RequestInterceptMiddleware> _logger = logger;
        private readonly RequestDelegate _next = next;

        public async Task Invoke(HttpContext ctx){
            Console.WriteLine($"Request intercept: {ctx.Request}");
            await _next(ctx);
        } 
    }

    public static class RequestIntercept {
        public static IApplicationBuilder UseRequestIntercetor(this IApplicationBuilder app){
            app.UseMiddleware<RequestInterceptMiddleware>();
            return app;
        }
    }
}