using ErrorHandlingApp.Web.Filters;
using ErrorHandlingApp.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ErrorHandlingApp.Web.Controllers
{
    [CustomHandleExceptionFilterAttribute(ErrorPage = "Error1")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[CustomHandleExceptionFilterAttribute(ErrorPage = "Error1")]
        public IActionResult Index()
        {
            int value1 = 5, value2 = 0;
            int result = value1 / value2;

            return View();
        }

        //[CustomHandleExceptionFilterAttribute(ErrorPage = "Error2")]
        public IActionResult Privacy()
        {
            throw new FileNotFoundException();
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //uygulamanın herhangi bir yerinde gelen hatayı yakalıyoruz
            var ex = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.Path = ex.Path;
            ViewBag.Message = ex.Error.Message;
            ViewBag.StackTrace = ex.Error.StackTrace;

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Error1()
        {
            return View();
        }

    }
}