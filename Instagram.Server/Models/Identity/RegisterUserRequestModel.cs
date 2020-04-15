using System.ComponentModel.DataAnnotations;

namespace Instagram.Server.Models.Identity
{
    public class RegisterUserRequestModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
