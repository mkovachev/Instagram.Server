using System.ComponentModel.DataAnnotations;
using static Instagram.Server.Data.DataValidator.Item;

namespace Instagram.Server.Features.Items.Models
{
    public class ItemUpdateRequestModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ItemsDescriptionMaxLength)]
        public string Description { get; set; }
    }
}
