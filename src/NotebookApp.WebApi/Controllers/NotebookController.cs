using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace NotebookApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NotebookController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            var t = new List<string>
            {
                "note 1", "note 2", "note 3"
            };
            return new JsonResult(t);
        }

        [HttpGet("auth")]
        [Authorize]
        public IActionResult Auth()
        {
            var t = new List<string>
            {
                "note 4", "note 5", "note 6"
            };
            return new JsonResult(t);
        }

        [HttpGet("secure")]
        [Authorize(Roles = "Admin")]
        public IActionResult Secure()
        {
            var t = new List<string>
            {
                "note 7", "note 8", "note 9"
            };
            return new JsonResult(t);
        }

        [HttpGet("my")]
        [Authorize]
        public IActionResult My()
        {
            var t = new List<string>
            {
                "note 10", "note 11", "note 12"
            };
            return new JsonResult(t);
        }
    }
}
