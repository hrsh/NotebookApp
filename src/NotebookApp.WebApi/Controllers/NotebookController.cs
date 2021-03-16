using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace NotebookApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NotebookController : ControllerBase
    {
        public NotebookController()
        {

        }

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
        [Authorize("MustOwnImage")]
        public IActionResult Auth()
        {
            var ownerId = User
                .Claims.
                FirstOrDefault(c => c.Type == "sub")
                ?.Value;

            var t = new List<string>
            {
                "note 4", "note 5", "note 6", ownerId
            };
            return new JsonResult(t);
        }

        [HttpGet("secure")]
        [Authorize("MustOwnImage")]
        public IActionResult Secure()
        {
            var t = new List<string>
            {
                "note 7", "note 8", "note 9"
            };
            return new JsonResult(t);
        }

        [HttpGet("my")]
        [Authorize("MustOwnImage")]
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
