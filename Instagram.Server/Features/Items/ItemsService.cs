using Instagram.Server.Features.Items.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Instagram.Server.Features.Items
{
    public class ItemsService : IItemsService
    {
        public Task<IEnumerable<ItemListingServiceModel>> ByUser(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<int> Create(string imageUrl, string description, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ItemDetailsServiceModel> Details(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, string description, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
