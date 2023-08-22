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
        private readonly IOptionsMonitor<SmtpSettings> _option;

        public HomeController(ILogger<HomeController> logger, IOptionsMonitor<SmtpSettings> options)
        {
            _logger = logger;
            _option = options;
        }

        public IActionResult Index()
        {
            /*
             * IOptions: uygulama çalıştıktan sonra değişmez ve Singleton
             * IOptionsSnapshot: "  okunabilir ama scope olarak kalır.
             * IOptionsMonitpr: " okunabilir ve Singleton
             */

            _logger.LogInformation($"{nameof(Index)} isimli action çalıştı.\nÇalışma zamanı:{DateTime.Now}");

            return View(_option.CurrentValue);
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