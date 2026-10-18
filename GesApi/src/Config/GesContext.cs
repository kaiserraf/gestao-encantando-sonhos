using gesApi.src.ModelsEFCore;
using Microsoft.EntityFrameworkCore;

namespace gesApi.src.Config {
    public class GesContext : DbContext {
        public GesContext(DbContextOptions<GesContext> options) : base(options) { }

        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<ProfileTypes> ProfileTypes { get; set; }
        public DbSet<RefreshTokens> RefreshTokens { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}