using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public sealed class PoiContext : DbContext
    {
        public PoiContext(DbContextOptions<PoiContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Poi> Pois { get; private set; }
    }
}
