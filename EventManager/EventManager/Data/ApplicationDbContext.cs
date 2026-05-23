using EventManager.Model;
using EventManager.Model.AuthApp;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            //Database.Migrate();
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventParticipsnt> EventsParticipsnt { get; set; }

        public DbSet<AuthUser> AuthUsers { get; set; }

    }
}
