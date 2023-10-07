using LoggingApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoggingApp.Web.Controllers
{
    public class HomeController : Controller
    {
        //1.yol
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly ILoggerFactory _loggerFactory;

        public HomeController(ILoggerFactory logger)
        {
            _loggerFactory = logger;
        }

        public IActionResult Index()
        {
            var _logger = _loggerFactory.CreateLogger("HomeSınıfı");
            string message = "Index sayfasına girildi";

            //core, 3 provider sağlıyor; console, debug, EventSource, EventLog
            _logger.LogTrace(message);
            _logger.LogDebug(message);
            _logger.LogInformation(message);
            _logger.LogWarning(message);
            _logger.LogError(message);
            _logger.LogCritical(message);

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