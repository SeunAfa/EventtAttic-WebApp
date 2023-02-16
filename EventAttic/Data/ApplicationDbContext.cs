using EventAttic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventAttic.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event_Artist>().HasKey(ac => new
            {
                ac.ArtistId,
                ac.EventId
            });

            modelBuilder.Entity<Event_Artist>().HasOne(c => c.Event).WithMany(ac => ac.Events_Artists).HasForeignKey(c => c.EventId);
            modelBuilder.Entity<Event_Artist>().HasOne(a => a.Artist).WithMany(ac => ac.Events_Artists).HasForeignKey(a => a.ArtistId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Event_Artist> Events_Artists { get; set; }
        public DbSet<EventLocation> EventLocations { get; set; }
        public DbSet<Organiser> Organisers { get; set; }

        //Shopping Cart Tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }


    }
}
