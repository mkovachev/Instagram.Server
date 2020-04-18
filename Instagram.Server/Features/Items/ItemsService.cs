using Instagram.Server.Data;
using Instagram.Server.Data.Models;
using Instagram.Server.Features.Items.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Instagram.Server.Features.Items
{
    public class ItemsService : IItemsService
    {
        private readonly InstagramDbContext db;
        public ItemsService(InstagramDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(string imageUrl, string description, string userId)
        {
            var item = new Item
            {
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId
            };

            await this.db.Items.AddAsync(item);

            await this.db.SaveChangesAsync();

            return item.Id;
        }

        public async Task<bool> Update(int id, string description, string userId)
        {
            var item = await this.GetByIdAndByUserId(id, userId);

            if (item == null)
            {
                return false;
            }

            item.Description = description;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id, string userId)
        {
            var Item = await this.GetByIdAndByUserId(id, userId);

            if (Item == null)
            {
                return false;
            }

            this.db.Items.Remove(Item);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ItemListingServiceModel>> ByUser(string userId)
            => await this.db
                .Items
                .Where(c => c.UserId == userId)
                .Select(c => new ItemListingServiceModel
                {
                    Id = c.Id,
                    ImageUrl = c.ImageUrl
                })
                .ToListAsync();

        public async Task<ItemDetailsServiceModel> Details(int id)
            => await this.db
                .Items
                .Where(c => c.Id == id)
                .Select(c => new ItemDetailsServiceModel
                {
                    Id = c.Id,
                    UserId = c.UserId,
                    ImageUrl = c.ImageUrl,
                    Description = c.Description,
                    UserName = c.User.UserName
                })
                .FirstOrDefaultAsync();

        private async Task<Item> GetByIdAndByUserId(int id, string userId)
            => await this.db
                .Items
                .Where(c => c.Id == id && c.UserId == userId)
                .FirstOrDefaultAsync();
    }
}
