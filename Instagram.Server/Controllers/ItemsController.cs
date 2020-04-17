using Instagram.Server.Data;
using Instagram.Server.Data.Models;
using Instagram.Server.Infrastructure;
using Instagram.Server.Models.Items;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Instagram.Server.Controllers
{
    public class ItemsController : ApiController
    {
        private readonly InstagramDbContext db;

        public ItemsController(InstagramDbContext db)
        {
            this.db = db;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateItemRequestModel model)
        {
            var userId = this.User.GetId();

            var item = new Item
            {
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                UserId = userId
            };

            await this.db.Items.AddAsync(item);

            await this.db.SaveChangesAsync();

            return Created(nameof(this.Create), item.Id);
        }
    }
}
