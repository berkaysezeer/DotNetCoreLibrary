using Microsoft.AspNetCore.Mvc;
using NLogApp.Web.Models;
using System.Diagnostics;

namespace NLogApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            int value = 5, value2 = 0;
            int result;

            try
            {
                result = value / value2;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }


            _logger.LogInformation("Hello, this is the Index!");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Hello, this is the Privacy!");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}