using Microsoft.AspNetCore.Mvc;

namespace course.API.Filters
{
    public class IsExistsAttribute : TypeFilterAttribute
    {
        public string Entity { get; set; }

        public IsExistsAttribute() : base(typeof(IsExistsFilter))
        {
            Arguments = new object[] { Entity };
        }
    }
}
