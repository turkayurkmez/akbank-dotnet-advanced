using Microsoft.AspNetCore.Mvc;

namespace course.API.Filters
{
    public class IsExistsAttribute : TypeFilterAttribute
    {
        public IsExistsAttribute() : base(typeof(IsExistsFilter))
        {

        }
    }
}
