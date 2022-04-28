using Microsoft.EntityFrameworkCore;

namespace WebAPI_Restful_.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public DbSet<Advertisement> Advertisements { get; set;}
    }
}
