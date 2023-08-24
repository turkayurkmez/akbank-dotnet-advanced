using course.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace course.API.Filters
{
    public class IsExistsFilter : IAsyncActionFilter
    {
        private readonly ICourseService _courseService;

        public IsExistsFilter(ICourseService courseService)
        {
            _courseService = courseService;


        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //1. action metodunun argümanlarında id var mı?
            if (!context.ActionArguments.ContainsKey("id"))
            {
                context.Result = new BadRequestObjectResult(new { message = $"{context.ActionDescriptor.DisplayName} action'u id parametresi almalı!" });

                return;
            }

            //2. id int mi?

            if (!(context.ActionArguments["id"] is int id))
            {
                context.Result = new BadRequestObjectResult(new { message = $"{context.ActionDescriptor.DisplayName} action'u id parametresi sayı tipinde olmalı!" });

                return;
            }

            //3. kurs var mı?
            if (!(await _courseService.IsExists(id)))
            {
                context.Result = new NotFoundObjectResult(new { message = $"{id} id'li kurs db'de yok!" });

                return;
            }

            await next();

        }
    }
}
