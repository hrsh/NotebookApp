using Microsoft.AspNetCore.Mvc;

namespace NotebookApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("NotbookApp.WebApi");
        }
    }
}
