namespace createCustomMiddleware.Middlewares
{
    public class JSonBodyMiddleware
    {
        private readonly RequestDelegate _next;

        public JSonBodyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //bu middleeare ne iş yapacaksa onu bu metot yapar ve ardından  sonraki middleware'a (_next) gönderir.
            //amaç:
            //gelen request POST ise ve gövdede JSON içeriyorsa; bu içeriği ayır.

            if (context.Request.Method == "POST" && context.Request.ContentType.StartsWith("application/json"))
            {

            }


            await _next(context);
        }
    }
}
