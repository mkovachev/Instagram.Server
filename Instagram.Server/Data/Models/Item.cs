using System.ComponentModel.DataAnnotations;

namespace Instagram.Server.Data.Models
{
    public class Item
    {
        public int Id { get; set; }

        [MaxLength(1000)]
        public int Description { get; set; }

        //[Required]
        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
