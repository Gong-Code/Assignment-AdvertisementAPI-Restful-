using Microsoft.EntityFrameworkCore;

namespace AdvertisementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Advertisement> Advertisements { get; set; }
    }
}
