using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Server.Controllers
{
    public class HomeController : ApiController
    {
        [Authorize]
        public IActionResult Get()
        {
            return Ok("works");
        }
    }
}
