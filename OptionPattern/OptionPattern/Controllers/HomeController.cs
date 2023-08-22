using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OptionPattern.Models;
using OptionPattern.Settings;
using System.Diagnostics;

namespace OptionPattern.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SmtpSettings _option;

        public HomeController(ILogger<HomeController> logger, IOptions<SmtpSettings> options)
        {
            _logger = logger;
            _option = options.Value;
        }

        public IActionResult Index()
        {

            return View(_option);
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