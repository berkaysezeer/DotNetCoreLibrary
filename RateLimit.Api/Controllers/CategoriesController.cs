using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RateLimit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCategory()
        {
            return Ok(new { Id = 1, Title = "Kırtasiye" });
        }

        [HttpPost]
        public IActionResult AddCategory()
        {
            return Ok(new { Status = "Succsess" });
        }
    }
}
