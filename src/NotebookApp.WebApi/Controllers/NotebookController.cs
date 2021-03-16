using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
        [Authorize]
        public IActionResult Auth()
        {
            //var l = new Dictionary<string, string>();
            //foreach (var c in User.Claims)
            //    l.Add(c.Type, c.Value);

            string ownerId = "";
            //if (l.Any())
                ownerId = User
                    .Claims
                    .FirstOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
                    ?.Value;

            var x = User.Claims.FirstOrDefault(c => c.Type == "sub");
            var y = x?.Value;

            var t = new List<string>
            {
                "note 4", "note 5", "note 6", ownerId, y
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
        [Authorize(Roles = "Mom")]
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
