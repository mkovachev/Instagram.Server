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

        [HttpPut]
        public async Task<ActionResult> Update(ItemUpdateRequestModel model)
        {
            var userId = this.User.GetId();

            var updated = await this.itemsService.Update(
                model.Id,
                model.Description,
                userId);

            if (!updated)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        [Route("id")]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = this.User.GetId();

            var deleted = await this.itemsService.Delete(id, userId);

            if (!deleted)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
