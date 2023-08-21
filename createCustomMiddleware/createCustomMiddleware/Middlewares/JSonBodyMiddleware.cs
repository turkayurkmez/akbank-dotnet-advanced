using System.Text;

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
                using var reader = new StreamReader(context.Request.Body);
                var json = await reader.ReadToEndAsync();

                //context.Request.Body nesnesini okuyarak, okuma pozisyonunu (current cursor) değiştirdiniz. Request'in tekrar okunabilir olması için pozisyonu resetlemelesiniz. Aksi halde, endpoint okuma yapamaz ve gıcık bir hata alırsınız.
                var content = Encoding.UTF8.GetBytes(json);
                var stream = new MemoryStream();
                stream.Write(content, 0, content.Length);
                context.Request.Body = stream;
                context.Request.Body.Seek(0, SeekOrigin.Begin);
                context.Items["jsonbody"] = json;
            }


            await _next(context);
        }
    }
}
