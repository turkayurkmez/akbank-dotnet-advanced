using course.Application.Services;
using course.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace course.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICourseService _courseService;
        public HomeController(ILogger<HomeController> logger, ICourseService courseService)
        {
            _logger = logger;
            _courseService = courseService;
        }

        public async Task<IActionResult> Index(int pageNo = 1)
        {
            var courses = await _courseService.GetCourses();

            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = pageNo,
                PageSize = 2,
                TotalItemsCount = courses.Count()
            };
            //var pageSize = 2;
            //var total = Math.Ceiling((decimal)courses.Count() / pageSize);
            //ViewBag.Total = total;

            var paginated = courses.OrderBy(c => c.Id)
                                   .Skip((pageNo - 1) * pagingInfo.PageSize)
                                   .Take(pagingInfo.PageSize)
                                   .ToList();



            HomeIndexViewModel model = new HomeIndexViewModel
            {
                CourseLists = paginated,
                PagingInfo = pagingInfo
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}