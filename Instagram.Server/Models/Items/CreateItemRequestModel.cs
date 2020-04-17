using System.ComponentModel.DataAnnotations;

namespace Instagram.Server.Models.Items
{
    public class CreateItemRequestModel
    {
        [MaxLength(1000)]
        public int Description { get; set; }

        //[Required]
        public string ImageUrl { get; set; }
    }
}
