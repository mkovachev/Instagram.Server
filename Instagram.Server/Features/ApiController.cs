using Microsoft.AspNetCore.Mvc;

namespace Instagram.Server.Features
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
