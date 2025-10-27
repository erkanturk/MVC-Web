namespace _14_Middlewares.Middlewares
{
    public class RequestLogginMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestLogginMiddleware(RequestDelegate next)
        {
            _next= next;//DI dependency injection Dışa bağımlılık enjeksiyonu 
            //Bu middleware'den sonra gelen middleware'i temsil eder.
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var message = $"Middleware çalıştı: {context.Request.Path}";//İstek yolu
            context.Items["MiddlewareMessage"]=message;//Context.Items ile veriyi saklıyoruz.

            await _next(context);//Sonraki middleware'e geçiş yapıyoruz.

            Console.WriteLine("Yanıt gönderildi: "+context.Response.StatusCode);//Yanıt durumu
        }
    }
}
