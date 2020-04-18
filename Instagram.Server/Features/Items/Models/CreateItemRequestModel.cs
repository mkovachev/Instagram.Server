using System.ComponentModel.DataAnnotations;
using static Instagram.Server.Data.DataValidator.Item;

namespace Instagram.Server.Features.Items.Models
{
    public class CreateItemRequestModel
    {
        [MaxLength(MaxDescriptionLenght)]
        public string Description { get; set; }

        //[Required]
        public string ImageUrl { get; set; }
    }
}
