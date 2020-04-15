using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Server.Data
{
    public class InstagramDbContext : IdentityDbContext
    {
        public InstagramDbContext(DbContextOptions<InstagramDbContext> options)
            : base(options)
        {
        }
    }
}
