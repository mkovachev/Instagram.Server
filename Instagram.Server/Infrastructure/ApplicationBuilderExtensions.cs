using Instagram.Server.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Instagram.Server.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<InstagramDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
