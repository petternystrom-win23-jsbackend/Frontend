using Frontend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Frontend.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<NewsletterSubscription> NewsletterSubscriptions { get; set; }

    }
}
