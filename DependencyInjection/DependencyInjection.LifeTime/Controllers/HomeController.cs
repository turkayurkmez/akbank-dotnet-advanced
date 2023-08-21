using DependencyInjection.LifeTime.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DependencyInjection.LifeTime.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISingleton _singleton;
        private readonly IScoped _scoped;
        private readonly ITransient _transient;
        private readonly GuidService _guidService;

        public HomeController(ILogger<HomeController> logger, ISingleton singleton, IScoped scoped, ITransient transient, GuidService guidService)
        {
            _logger = logger;
            _singleton = singleton;
            _scoped = scoped;
            _transient = transient;
            _guidService = guidService;

        }

        public IActionResult Index()
        {
            ViewBag.Singleton = _singleton.Guid.ToString();
            ViewBag.Scoped = _scoped.Guid.ToString();
            ViewBag.Transient = _transient.Guid.ToString();

            ViewBag.ServiceSingleton = _guidService.Singleton.Guid.ToString();
            ViewBag.ServiceScoped = _guidService.Scoped.Guid.ToString();
            ViewBag.ServiceTransient = _guidService.Transient.Guid.ToString();
            return View();
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