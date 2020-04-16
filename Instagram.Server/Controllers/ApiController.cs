using Microsoft.AspNetCore.Mvc;

namespace Instagram.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
