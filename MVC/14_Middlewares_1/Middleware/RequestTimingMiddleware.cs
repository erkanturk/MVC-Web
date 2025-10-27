using System.Diagnostics;

namespace _14_Middlewares_1.Middleware
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestTimingMiddleware(RequestDelegate next)
        {
            _next= next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var watch = Stopwatch.StartNew();//Zamanlayıcıyı başlatıyoruz.
            Console.WriteLine($"İstek başladı: {context.Request.Path}");
            await _next(context);//Sonraki middleware'e geçiş yapıyoruz.
            watch.Stop();//Zamanlayıcıyı durduruyoruz.
            var elapsedMs = watch.ElapsedMilliseconds;//Geçen süreyi alıyoruz.

            if (elapsedMs>1000)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine($"Yavaş İstek: {context.Request.Path}");
            }
            else if (elapsedMs>500)
            {
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.WriteLine($"Orta İstek: {context.Request.Path}");
            }
            else
            {
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine($"Hızlı İstek: {context.Request.Path}");
            }
            Console.ResetColor();

            context.Response.Headers.Add("X-Response-Time", $"{elapsedMs} ms");
        }
    }
}
