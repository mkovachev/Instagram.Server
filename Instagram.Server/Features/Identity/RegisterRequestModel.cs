using System.ComponentModel.DataAnnotations;

namespace Instagram.Server.Features.Identity
{
    public class RegisterRequestModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
