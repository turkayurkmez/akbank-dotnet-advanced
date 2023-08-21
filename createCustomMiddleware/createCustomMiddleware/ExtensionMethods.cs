using createCustomMiddleware.Middlewares;

namespace createCustomMiddleware
{
    public static class ExtensionMethods
    {
        public static IApplicationBuilder UseBadwordsHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<JSonBodyMiddleware>();
            app.UseMiddleware<BadwordsHandlerMiddleware>();

            return app;
        }
    }
}
