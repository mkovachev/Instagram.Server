namespace Instagram.Server.Features.Items.Models
{
    public class ItemDetailsServiceModel : ItemListingServiceModel
    {
        public string UserId { get; set; }

        public string Description { get; set; }

        public string UserName { get; set; }
    }
}