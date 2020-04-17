using Instagram.Server.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Server.Data
{
    public class InstagramDbContext : IdentityDbContext<User>
    {
        public InstagramDbContext(DbContextOptions<InstagramDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasMany(u => u.Items)
                .WithOne();

            builder
                .Entity<Item>()
                .HasOne(i => i.User)
                .WithMany(u => u.Items)
                .HasForeignKey(i => i.UserId)
                .IsRequired();
            //.OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<Item>()
            //    .Property(i => i.UserId)
            //    .IsRequired();

            base.OnModelCreating(builder);

        }
    }
}
