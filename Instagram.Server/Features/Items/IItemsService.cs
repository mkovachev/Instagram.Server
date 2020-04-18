using System.Collections.Generic;
using System.Threading.Tasks;

namespace Instagram.Server.Features.Items
{
    public interface IItemsService
    {
        public Task<int> Create(string imageUrl, string description, string userId);

        public Task<bool> Update(int id, string description, string userId);

        public Task<bool> Delete(int id, string userId);

        public Task<IEnumerable<ItemListingServiceModel>> ByUser(string userId);

        public Task<ItemDetailsServiceModel> Details(int id);
    }
}
