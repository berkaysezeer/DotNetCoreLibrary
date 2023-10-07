using ErrorHandlingApp.Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandlingApp.Web.Controllers
{
    [CustomHandleExceptionFilterAttribute(ErrorPage = "Error2")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            throw new AggregateException();
            return View();
        }

        public IActionResult Detail()
        {
            throw new FileNotFoundException();
            return View();
        }

        public IActionResult Error2()
        {
            return View();
        }
    }
}
