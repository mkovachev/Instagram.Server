using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Instagram.Server.Controllers
{
    public class ItemsController : ApiController
    {
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create()
        {

        }
    }
}
