using DependencyInjection.Using.Models;
using DependencyInjection.Using.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DependencyInjection.Using.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService service;

        public HomeController(ILogger<HomeController> logger, IProductService service)
        {
            _logger = logger;
            this.service = service;
        }




        public IActionResult Index()
        {
            //var service = new ProductService();
            var products = service.GetProducts();
            return Json(products);
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