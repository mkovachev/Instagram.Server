using System.ComponentModel.DataAnnotations;
using static Instagram.Server.Data.DataValidator.Item;

namespace Instagram.Server.Data.Models
{
    public class Item
    {
        public int Id { get; set; }

        [MaxLength(MaxDescriptionLenght)]
        public string Description { get; set; }

        //[Required]
        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
