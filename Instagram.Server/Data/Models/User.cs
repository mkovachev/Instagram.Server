using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Instagram.Server.Data.Models
{
    public class User : IdentityUser
    {
        public IEnumerable<Item> Items { get; } = new HashSet<Item>();
    }
}
