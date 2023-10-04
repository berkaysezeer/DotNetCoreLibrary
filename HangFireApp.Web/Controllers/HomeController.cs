using HangFireApp.Web.BackgroundJobs;
using HangFireApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HangFireApp.Web.Controllers
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

        public IActionResult SignUp()
        {
            //üye kayıt işlemi gerçekleşen metot

            //job oluşturma
            FireAndForgetJobs.EmailSendToUserJob("berkaysezeer", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ");

            return View();
        }

        public IActionResult ImageSave()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ImageSave(IFormFile image)
        {
            string newFileName = String.Empty;

            if (image != null && image.Length > 0)
            {
                //abc.jpg
                newFileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", newFileName);

                //FileStream IDisposable implement ettiği için using kullanıyoruz. yani dispose etmemize gerek kalmıyor
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                string jobId = DelayedJobs.WatermarkAdderJob(newFileName, "HangFire");
                //string jobId = DelayedJobs.AddWatermarkJob(newFileName, "HangFire");
            }

            return View();
        }
    }
}