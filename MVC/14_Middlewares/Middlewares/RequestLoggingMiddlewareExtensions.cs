namespace _14_Middlewares.Middlewares
{
    public static class RequestLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLogginMiddleware>();
            //Bu method, RequestLogginMiddleware sınıfını uygulama (Httpİsteği PipleLine) boru hattına ekler.
            //IApplicationBuilder arayüzünü genişletir ve böylece bu middleware'i kolayca ekleyebiliriz.
        }
    }
}
