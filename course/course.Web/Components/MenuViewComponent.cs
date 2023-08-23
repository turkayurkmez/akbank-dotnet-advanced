using course.Entities;
using Microsoft.AspNetCore.Mvc;

namespace course.Web.Components
{
    public class MenuViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            var categories = new List<Category>
            {
                new(){ Id=1, Name="Yabancı dil"},
                new(){ Id=2, Name="Sanat"},
                new(){ Id=3, Name="Teknoloji"}

            };

            return View(categories);
        }
    }
}
