using Microsoft.EntityFrameworkCore;
using YongdingSun.API.Modles.Domain;

namespace YongdingSun.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Image> Images { get; set; }
    }
}
