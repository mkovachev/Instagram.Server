using Instagram.Server.Features.Items.Models;
using Instagram.Server.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Instagram.Server.Features.Items
{
    public class ItemsController : ApiController
    {
        private readonly IItemsService itemsService;

        public ItemsController(IItemsService itemsService)
        {
            this.itemsService = itemsService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(ItemCreateRequestModel model)
        {
            var userId = this.User.GetId();

            var id = await this.itemsService.Create(model.ImageUrl, model.Description, userId);

            return Created(nameof(this.Create), id);
        }
    }
}
