using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Server.Controllers
{
    public class HomeController : ApiBaseController
    {
        //[Authorize]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
