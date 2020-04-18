using System.ComponentModel.DataAnnotations;
using static Instagram.Server.Data.DataValidator.Item;

namespace Instagram.Server.Features.Items.Models
{
    public class ItemCreateRequestModel
    {
        [MaxLength(ItemsDescriptionMaxLength)]
        public string Description { get; set; }

        //[Required]
        public string ImageUrl { get; set; }
    }
}
