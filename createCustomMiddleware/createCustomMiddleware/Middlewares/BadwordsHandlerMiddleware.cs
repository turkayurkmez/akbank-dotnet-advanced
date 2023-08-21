namespace createCustomMiddleware.Middlewares
{
    public class BadwordsHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public BadwordsHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Items.TryGetValue("jsonbody", out object? json))
            {
                //eğer json gövdesi içinde istenmeyen kelime varsa, o zaman hata döndür
                var badWords = new List<string> { "kaba", "kötü", "çirkin", "pis" };
                var jsonContent = (string?)json;
                if (badWords.Any(jsonContent.Contains))
                {
                    context.Response.StatusCode = 400;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsJsonAsync(new { message = "Bu yorumda, hoş olmayan kelimeler var" });
                    return;
                }
            }

            await _next(context);
        }
    }
}
