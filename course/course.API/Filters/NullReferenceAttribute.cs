using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace course.API.Filters
{
    public class NullReferenceAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is NullReferenceException)
            {
                var message = new
                {
                    Info = $"{context.ActionDescriptor.DisplayName} action'u içerisinde null olarak tutulan bir nesne var.",
                    Source = context.Exception.Source,
                    StackTrace = context.Exception.StackTrace
                };
                context.Result = new BadRequestObjectResult(message);
            }
        }
    }
}
